using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCharacter : CharacterBase
{  
    private const string DASH_ANIMATION_NAME = "DashDistAnimation";
    private const string HEAVY_ATTACK_ANIMATION_NAME = "HeavyAttackDistAnimation";
    private const string LIGHT_ATTACK_ANIMATION_NAME = "LightAtackDistAnimation";
    private const string SPECIAL_ATTACK_ANIMATION_NAME = "SpecialAttackDistAnimation";
    private Arrow arrowFunctional;
    private int arrowsSpecialAmount = 3;
    private Arrow[] arrowsFunctional;
    public Transform arrowReference;

    
    protected override void Start()
    {
        base.Start();
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
        arrow.transform.localScale = new Vector3(2, 1, 2);
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
