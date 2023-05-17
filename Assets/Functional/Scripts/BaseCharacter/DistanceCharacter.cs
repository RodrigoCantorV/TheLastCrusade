using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCharacter : CharacterBase
{
    // Start is called before the first frame update
    private const string dashAnimation = "DashDistAnimation";
    private const string heavyAttackAnimation = "HeavyAttackDistAnimation";
    private const string lightAttackAnimation = "LightAtackDistAnimation";
    public Arrow arrowFunctional;    
    public Transform arrowReference;
  

    protected override void Start()
    {
        base.Start();
        playerSpeed = 10.0f;
        dashAnimationName = dashAnimation;
        heavyAttackAnimationName = heavyAttackAnimation;
        lightAttackAnimationName = lightAttackAnimation;
        



    }

    public void GenerateArrow()
    {
        GameObject arrow =  ArrowPool.Instance.RequestArrow();
        arrow.transform.position = arrowReference.position;
        arrow.transform.rotation = arrowReference.rotation;
        arrowFunctional = arrow.GetComponent<Arrow>();
    }



    public void ShotArrow()
    {
        arrowFunctional.ShotArrow();
    }

    public void ShotChargedArrow()
    {
        arrowFunctional.ShotChargedArrow();
    }





}
