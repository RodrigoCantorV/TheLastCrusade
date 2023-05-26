using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCharacter : CharacterBase
{  
    private const string DASH_ANIMATION_NAME = "DashDistance";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "HardAttackDist";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "LightAttackDistance";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "SpecialAttackDist";
    private Arrow arrowFunctional;
    private int arrowsSpecialAmount = 3;
    private Arrow[] arrowsFunctional;
    public Transform arrowReference;
    protected override void Start()
    {
        base.Start();
        base.currentLife = 120f;
        base.characterMaxLife = 120f;
        
        arrowsFunctional = new Arrow[arrowsSpecialAmount];
        dashAnimationName = DASH_ANIMATION_NAME;
        heavyAttackAnimationName = HEAVY_ATTACK_ANIMATION_NAME;
        lightAttackAnimationName = LIGHT_ATTACK_ANIMATION_NAME;
        specialAttackAnimationName = SPECIAL_ATTACK_ANIMATION_NAME;
    }

    public void GenerateArrow()
    {
        GameObject arrow =  ArrowPool.Instance.RequestArrow();
        arrow.transform.position = arrowReference.position;
        arrow.transform.rotation = arrowReference.rotation;
        arrow.transform.localScale = new Vector3(3, 1, 3);
        arrowFunctional = arrow.GetComponent<Arrow>();
    }
    public void GenerateArrows()
    {
        for(int i=0; i < arrowsSpecialAmount; i++)
        {
            GameObject arrow = ArrowPool.Instance.RequestArrow();
            arrow.transform.position = arrowReference.position;
            arrow.transform.rotation = arrowReference.rotation;
            arrow.transform.localScale = new Vector3(5, 2, 5);
            arrowsFunctional[i] = arrow.GetComponent<Arrow>();
            
        }
    }
    public void ShotArrow()
    {
        arrowFunctional.ShotArrow();
    }

    public void ShotChargedArrow()
    {
        arrowFunctional.ShotChargedArrow();
    }
    public void ShotSpecialAttack()
    {
        for(int i=0;i<arrowsSpecialAmount; i++)
        {
            arrowsFunctional[i].ShotSpecialAttack(i);
        }
    }
}
