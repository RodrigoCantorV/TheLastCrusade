using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCharacter : CharacterBase
{
    private const string DASH_ANIMATION_NAME = "DashMiddleAnimation";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "HeavyAttackMiddleAnimation";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "LightAttackMiddleAnimation";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "HeavyAttackMiddleAnimation";/// CAMBIAR A NOMBRE DE ANIMACION SPECIAL
    private Animation animationLightAttack;
    private Animation animationHardAttack;

    protected override void Start()
    {
        base.Start();
        // Media velocidad
        playerSpeed = 8.0f;
        // Dash media
        dashSpeed = 6.0f;
        dashAnimationName = DASH_ANIMATION_NAME;
        heavyAttackAnimationName = HEAVY_ATTACK_ANIMATION_NAME;
        lightAttackAnimationName = LIGHT_ATTACK_ANIMATION_NAME;
        specialAttackAnimationName = SPECIAL_ATTACK_ANIMATION_NAME;

        base.lightAttackDamage = 20.0f;
        base.heavyAttackDamage = 30.0f;
        // StartDealDamage();
        // EndDealDamage();

    }
    public void SpecialAttack()
    {
        StartCoroutine(SpecialAttackCorroutine());
    }

    IEnumerator SpecialAttackCorroutine()
    {
        animationLightAttack["LightAttack"].speed = 3;
        animationHardAttack["HeavyAttack"].speed = 3;
        base.lightAttackDamage = 65.0f;
        base.heavyAttackDamage = 130.0f;
        yield return new WaitForSeconds(10);
        animationLightAttack["LightAttack"].speed = 1;
        animationHardAttack["HeavyAttack"].speed = 1;
        base.lightAttackDamage = 20.0f;
        base.heavyAttackDamage = 30.0f;
    }
}



