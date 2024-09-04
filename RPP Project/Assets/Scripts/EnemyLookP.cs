using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookP : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;  // Certifique-se de que este seja o ponto de disparo do proj�til

    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        // Calcula a dire��o do jogador em rela��o ao inimigo
        Vector2 direction = player.position - transform.position;

        // Calcula o �ngulo em que o inimigo deve rotacionar para olhar para o jogador
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica a rota��o ao inimigo e ao firePoint
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Se o firePoint n�o estiver como filho do inimigo ou necessitar de ajustes espec�ficos
        if (firePoint != null)
        {
            firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}