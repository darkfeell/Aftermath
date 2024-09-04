using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float attackRange = 3f;  // Alcance de ataque
    public float attackCooldown = 2f;  // Tempo de espera entre ataques

    private bool canAttack = true;

    public void Tattack(Transform player, float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange && canAttack)
        {
            StartCoroutine(Attack(player));
        }
    }

    private IEnumerator Attack(Transform player)
    {
        canAttack = false;

        // Instancia o projétil na posição do firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Calcula a direção em que o projétil deve ser lançado
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Define a velocidade do projétil
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;

        // Espera pelo cooldown antes de permitir o próximo ataque
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
