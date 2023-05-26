using System.Collections.Generic;
using UnityEngine;
 
public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealtDamage;
    // List<GameObject> hasDealtDamage;
 
    [SerializeField] float weaponLength;
    public float weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
        // hasDealtDamage = new List<GameObject>();
    }
 
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;
 
            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                /*if(hit.transform.TryGetComponent(out Enemy enemy))
                {
                    Debug.Log("Ataco al enemigo");
                    enemy.TakeDamage(weaponDamage);
                    hasDealtDamage = true;
                }*/

                if(hit.transform.TryGetComponent(out EnemyShortDistance enemyShortDistance))
                {
                    Debug.Log("Ataco al esqueleto");
                    enemyShortDistance.TakeDamage(weaponDamage);
                    hasDealtDamage = true;
                }
                if(hit.transform.TryGetComponent(out EnemyLongDistance enemyLongDistance))
                {
                    Debug.Log("Ataco al mago");
                    enemyLongDistance.TakeDamage(weaponDamage);
                    hasDealtDamage = true;
                }
                
                // if (hit.transform.TryGetComponent(out EnemyAI enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                // {
                //     Debug.Log("Golpeo enemigo");
                //     // enemy.TakeDamage(weaponDamage);
                //     // enemy.HitVFX(hit.point);
                //     // hasDealtDamage.Add(hit.transform.gameObject);
                // }
            }
        }
    }
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false; 
        // hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    public void SetDamage(float damage)
    {
        weaponDamage = damage;
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
