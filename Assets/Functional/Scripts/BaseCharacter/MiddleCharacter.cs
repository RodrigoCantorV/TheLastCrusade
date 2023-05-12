using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCharacter : CharacterBase
{

    protected override void Start()
    {
        base.Start();
        playerSpeed = 8f;
        dashSpeed = 5.0f;
        hola = "hola";
    }

    // Cambio posible
    //private void Start()
    //{
    //    controller = GetComponent<CharacterController>();
    //    animator = GetComponent<Animator>();
    //    playerInput = GetComponent<PlayerInput>();
    //    //dealer = GetComponentInChildren<DamageDealer>();

    //    movementSM = new StateMachine();
    //    movement = new StandingState(this, movementSM);
    //    dashing = new DashState(this, movementSM);
    //    heavyAttacking = new HeavyAttackState(this, movementSM);
    //    lightAttacking = new LightAttackState(this, movementSM);

    //    movementSM.Initialize(movement);
    //}

}
