using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCharacter : CharacterBase
{
    private const string dashAnimation = "DashMiddleAnimation";
    private const string heavyAttackAnimation = "HeavyAttackMiddleAnimation";
    private const string lightAttackAnimation = "LightAttackMiddleAnimation";

    protected override void Start()
    {
        base.Start();
        // Media velocidad
        playerSpeed = 8.0f;
        // Dash media
        dashSpeed = 6.0f;
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
