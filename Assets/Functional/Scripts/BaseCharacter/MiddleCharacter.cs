using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCharacter : CharacterBase
{

    protected override void Start()
    {
        base.Start();
        // Media velocidad
        playerSpeed = 10.0f;

        // Dash media
        dashSpeed = 5.0f;
        hola = "hola";

        // Media vida: seria la mitad del total de vida entre el Melee y Large character
        life = 50.0f;

        // Ulti, buffdaño, velocidad ( +20% PD, +15% VM )

        // Ataque rápido: cono ( 30 - 40 PD)

        // Ataque Fuerte: Patada(empuja a los enemigos hacia atrás)(70 PD)
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
