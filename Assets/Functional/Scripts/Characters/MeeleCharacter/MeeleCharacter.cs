using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleCharacter : CharacterBase
{
    public AudioSource audioSource;
    public AudioClip attackSound;
    public AudioClip patadaSound;
    bool isAttacking; 

    private const string DASH_ANIMATION_NAME = "DashMeeleAnimation";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "HeavyAttackMeeleAnimation";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "LightAtackMeeletAnimation";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "SpecialAttackMeeleAnimation";// CAMBIAR A NOMBRE DE ANIMACION SPECIAL

    

    protected override void Start()
    {
        base.Start();
        base.lightAttackDamage = 65.0f;
        base.heavyAttackDamage = 130.0f;

        //isAttacking = false;
        dashAnimationName = DASH_ANIMATION_NAME;
        heavyAttackAnimationName = HEAVY_ATTACK_ANIMATION_NAME;
        lightAttackAnimationName = LIGHT_ATTACK_ANIMATION_NAME;
        specialAttackAnimationName = SPECIAL_ATTACK_ANIMATION_NAME;

        if(isAttacking == true)
        {
            StartDealDamageLightAttack();
            EndDealDamageLightAttack();

        }

        if(isAttacking == true)
        {
            StartDealDamageHeavyAttack();
            EndDealDamageHeavyAttack();
        }

        //audioSource = GameObject.Find("")?.GetComponent<AudioSource>();
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = attackSound;
    }

    protected override void StartDealDamageLightAttack()
    {
        base.StartDealDamageLightAttack();
        GetComponentInChildren<DamageDealer>().SetDamage(base.lightAttackDamage);
        GetComponentInChildren<DamageDealer>().StartDealDamage();
        audioSource.clip = attackSound;
        audioSource.Play();
    }

    protected override void EndDealDamageLightAttack()
    {
        base.EndDealDamageLightAttack();
        GetComponentInChildren<DamageDealer>().EndDealDamage();
        isAttacking = false;
    }

    protected override void StartDealDamageHeavyAttack()
    {
        base.StartDealDamageHeavyAttack();
        GetComponentInChildren<DamageDealer>().SetDamage(base.heavyAttackDamage);
        GetComponentInChildren<DamageDealer>().StartDealDamage();
        audioSource.clip = patadaSound;
        audioSource.time = 3.6f;
        audioSource.Play();
    }
    protected override void EndDealDamageHeavyAttack()
    {
        base.EndDealDamageHeavyAttack();
        GetComponentInChildren<DamageDealer>().EndDealDamage();
        isAttacking = false;
    }

}
