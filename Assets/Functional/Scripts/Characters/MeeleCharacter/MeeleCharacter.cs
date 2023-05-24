using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleCharacter : CharacterBase
{

    [SerializeField] private GameObject ultiParticlesObject;
    [SerializeField] private LayerMask whatAreDamageable;
    [SerializeField] private float radiusSphere;
    [SerializeField] private float KnockbackForce;

    private const string DASH_ANIMATION_NAME = "MeeleDashAnimation";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "MeeleHeavyAttackAnimation";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "MeeleLigthAttackAnimation";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "MeeleUltiAnimation";// CAMBIAR A NOMBRE DE ANIMACION SPECIAL

    protected override void Start()
    {
        base.Start();
        base.lightAttackDamage = 65.0f;
        base.heavyAttackDamage = 130.0f;

        dashAnimationName = DASH_ANIMATION_NAME;
        heavyAttackAnimationName = HEAVY_ATTACK_ANIMATION_NAME;
        lightAttackAnimationName = LIGHT_ATTACK_ANIMATION_NAME;
        specialAttackAnimationName = SPECIAL_ATTACK_ANIMATION_NAME;
    }

    protected override void StartDealDamageLightAttack()
    {
        base.StartDealDamageLightAttack();
        GetComponentInChildren<DamageDealer>().SetDamage(base.lightAttackDamage);
        GetComponentInChildren<DamageDealer>().StartDealDamage();
    }

    protected override void EndDealDamageLightAttack()
    {
        base.EndDealDamageLightAttack();
        GetComponentInChildren<DamageDealer>().EndDealDamage();     
    }

    protected override void StartDealDamageHeavyAttack()
    {
        base.StartDealDamageHeavyAttack();
        GetComponentInChildren<DamageDealer>().SetDamage(base.heavyAttackDamage);
        GetComponentInChildren<DamageDealer>().StartDealDamage();    
    }
    protected override void EndDealDamageHeavyAttack()
    {
        base.EndDealDamageHeavyAttack();
        GetComponentInChildren<DamageDealer>().EndDealDamage();   
    }

    protected override void StartDealDamageSpecialAttack()
    {
        base.StartDealDamageSpecialAttack();        
        ultiParticlesObject.SetActive(true);
        ultiParticlesObject.GetComponent<ParticleSystem>().Play();
        CheckForDamageable(base.specialAttackDamage);   
    }

    private void CheckForDamageable(float ultiDamage)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusSphere, whatAreDamageable);
        foreach(Collider c in colliders)
        {
            if (c.GetComponent<EnemyShortDistance>())
            {
                c.GetComponent<EnemyShortDistance>().transform.position -= c.transform.forward * Time.deltaTime * KnockbackForce;
                c.GetComponent<EnemyShortDistance>().TakeDamage(ultiDamage);
            }
        }
    }
}
