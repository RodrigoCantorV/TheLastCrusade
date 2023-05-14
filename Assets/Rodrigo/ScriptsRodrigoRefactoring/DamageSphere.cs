using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSphere : EnemyDamageDealer
{
    [SerializeField] float weaponRatio;
    float poo;

    public override void GenerateDamage()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= weaponRatio)
            {

                // health.TakeDamage(weaponDamage);
                // health.HitVFX(hit.point);
                Debug.Log("Atacando Jugador");
                hasDealtDamage = true;

            }
        }
    }

    public override void PaintGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponRatio);
    }
}
