using UnityEngine;

public class EnemyPatrol2D : MonoBehaviour
{
    public Transform player;
    public float detectionRange;
    public float detectionFlee;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float fleeSpeed = -4f;
    public Vector2[] patrolPoints;

    private int currentPatrolIndex;
    private Rigidbody2D rb;
    private EnemyAttack enemyAttack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPatrolIndex = 0;

        // Refer�ncia ao script de ataque
        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("Detection Range: " + distanceToPlayer);

        if (distanceToPlayer <= detectionRange && distanceToPlayer > detectionFlee)
        {
            ChasePlayer();
        }

        else if (distanceToPlayer <= detectionFlee && distanceToPlayer < detectionFlee)
        {
            FleePlayer();
        }
        else
        {
            Patrol();
        }

        // Chama a fun��o de ataque
        enemyAttack.Tattack(player, distanceToPlayer);
    }

    private void Patrol()
    {
        Vector2 targetPosition = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPosition, patrolSpeed);

        if (Vector2.Distance(rb.position, targetPosition) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    private void FleePlayer()
    {
        MoveTowards(player.position, fleeSpeed);
    }

    private void MoveTowards(Vector2 targetPosition, float speed)
    {
        Vector2 direction = (targetPosition - rb.position).normalized;
        rb.velocity = direction * speed;
    }
}
