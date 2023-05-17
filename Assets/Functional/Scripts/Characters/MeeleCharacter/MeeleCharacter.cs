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

        playerSpeed = 2.5f;
        dashAnimationName = dashAnimation;
        heavyAttackAnimationName = heavyAttackAnimation;
        lightAttackAnimationName = lightAttackAnimation;

        StartDealDamage();
        EndDealDamage();

    }

    protected override void StartDealDamage()
    {
        base.StartDealDamage();
        GetComponentInChildren<DamageDealer>().StartDealDamage(); 
    }

    protected override void EndDealDamage()
    {
        base.EndDealDamage();
        GetComponentInChildren<DamageDealer>().EndDealDamage();
    }

}
