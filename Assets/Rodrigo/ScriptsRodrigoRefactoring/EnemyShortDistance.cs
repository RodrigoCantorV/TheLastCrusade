using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShortDistance : Enemy
{
    protected override void AttackEnemy()
    {
        if (timePassed >= attackTime)
        {
            // Si la sitancia entre el enemigo y el player es menor al rango de ataque entonces que ataque
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
            }
        }
        timePassed += Time.deltaTime;
    }
}
