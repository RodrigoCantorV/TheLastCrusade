using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCharacter : CharacterBase
{
    // Start is called before the first frame update
    private const string dashAnimation = "DashDistAnimation";
    private const string heavyAttackAnimation = "HeavyAttackDistAnimation";
    private const string lightAttackAnimation = "LightAtackDistAnimation";
    

    protected override void Start()
    {
        base.Start();
        playerSpeed = 2.0f;
        dashAnimationName = dashAnimation;
        heavyAttackAnimationName = heavyAttackAnimation;
        lightAttackAnimationName = lightAttackAnimation;

    }



}
