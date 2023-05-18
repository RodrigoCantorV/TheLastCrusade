using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleCharacter : CharacterBase
{
    private const string DASH_ANIMATION_NAME = "DashMeeleAnimation";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "HeavyAttackMeeleAnimation";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "LightAtackMeeletAnimation";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "LightAtackMeeletAnimation";// CAMBIAR A NOMBRE DE ANIMACION SPECIAL

    

    protected override void Start()
    {
        base.Start();
        base.lightAttackDamage = 65.0f;
        base.heavyAttackDamage = 130.0f;

        dashAnimationName = DASH_ANIMATION_NAME;
        heavyAttackAnimationName = HEAVY_ATTACK_ANIMATION_NAME;
        lightAttackAnimationName = LIGHT_ATTACK_ANIMATION_NAME;
        specialAttackAnimationName = SPECIAL_ATTACK_ANIMATION_NAME;

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
