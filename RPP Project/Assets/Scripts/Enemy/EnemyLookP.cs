using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookP : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;  // Certifique-se de que este seja o ponto de disparo do projétil

    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        // Calcula a direção do jogador em relação ao inimigo
        Vector2 direction = player.position - transform.position;

        // Calcula o ângulo em que o inimigo deve rotacionar para olhar para o jogador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rotação ao inimigo e ao firePoint
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Se o firePoint não estiver como filho do inimigo ou necessitar de ajustes específicos
        if (firePoint != null)
        {
            firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}