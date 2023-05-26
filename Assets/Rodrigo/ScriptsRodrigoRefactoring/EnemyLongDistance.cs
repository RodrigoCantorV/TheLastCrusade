using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLongDistance : Enemy
{
    GameObject power;


    protected override void AttackEnemy()
    {
        if (timePassed >= attackTime)
        {
            // Si la sitancia entre el enemigo y el player es menor al rango de ataque entonces que ataque
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
                Invoke("CreatePower", .8f);
            }
        }
        timePassed += Time.deltaTime;
    }

    void CreatePower()
    {
       // power = PowerPool.Instance.RequestPower();
        power = GetComponentInChildren<PowerPool>().RequestPower();
        Vector3 position = transform.position;
        position = position + transform.forward * 5;
        position.y += 5f;

        power.transform.position = position;
        power.transform.localEulerAngles = transform.forward;
        StartDealDamage();
    }
}
