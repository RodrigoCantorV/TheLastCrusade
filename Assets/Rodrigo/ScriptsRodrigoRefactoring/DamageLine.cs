using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLine : EnemyDamageDealer
{
    [SerializeField] float weaponLength;

    public override void GenerateDamage()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                //  if (hit.transform.TryGetComponent(out HealthSystem health))
                if (hit.transform.TryGetComponent(out CharacterBase health))
                {
                    // health.TakeDamage(weaponDamage);
                    // health.HitVFX(hit.point);
                    Debug.Log("Atacando Jugador");
                    hasDealtDamage = true;
                }
            }
        }
    }

    public override void PaintGizmos()
    {
        Gizmos.color = Color.yellow;
        // Gizmos.DrawWireSphere(transform.position, 2);
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
