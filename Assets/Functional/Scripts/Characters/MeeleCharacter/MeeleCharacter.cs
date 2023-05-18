using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleCharacter : CharacterBase
{
    private const string dashAnimation = "DashMeeleAnimation";
    private const string heavyAttackAnimation = "HeavyAttackMeeleAnimation";
    private const string lightAttackAnimation = "LightAtackMeeletAnimation";
    

    protected override void Start()
    {
        base.Start();
        base.lightAttackDamage = 65.0f;
        base.heavyAttackDamage = 130.0f;

        dashAnimationName = dashAnimation;
        heavyAttackAnimationName = heavyAttackAnimation;
        lightAttackAnimationName = lightAttackAnimation;

        StartDealDamageLightAttack();
        EndDealDamageLightAttack();

        StartDealDamageHeavyAttack();
        EndDealDamageHeavyAttack();

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

}
