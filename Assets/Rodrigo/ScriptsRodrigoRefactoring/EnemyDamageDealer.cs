using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamageDealer : MonoBehaviour
{
    protected bool canDealDamage;
    protected bool hasDealtDamage;

   
    [SerializeField] float weaponDamage;
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
    GenerateDamage();
    }

    public abstract void GenerateDamage();

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }
    
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
       PaintGizmos();
    }

    public abstract void PaintGizmos();
}
