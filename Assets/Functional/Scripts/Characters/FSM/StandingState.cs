using UnityEngine;
using UnityEngine.InputSystem;

public class StandingState : State
{
    Vector3 currentVelocity;
    float playerSpeed;
    bool heavyAttack, lightAttack;
    bool dash;
    bool specialAttack;
    float playerSyncWithPointer = 90f;

    Vector3 cVelocity;

    public StandingState(CharacterBase _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        CharacterBase = _character;
        stateMachine = _stateMachine;
       
    }

    public override void Enter()
    {
        base.Enter();


        heavyAttack = false;
        lightAttack = false;
        specialAttack = false; 
        dash = false;
        input = Vector2.zero;
        velocity = Vector3.zero;
        currentVelocity = Vector3.zero;
     

        playerSpeed = CharacterBase.playerSpeed;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        
        if (dashAction.triggered)
        {
            dash = true;
        }
        if (lightAttackAction.triggered)
        {
            lightAttack = true;
           
        }    
        if (heavyAttackAction.triggered)
        {
            heavyAttack = true;
           
        }
        if (specialAttackAction.triggered && CharacterBase.specialCharges >=5)
        {
            specialAttack = true;
        }



        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * CharacterBase.transform.right.normalized + velocity.z * CharacterBase.transform.forward.normalized;
        velocity.y = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CharacterBase.animator.SetFloat("speed", input.magnitude, CharacterBase.delayAnimationTime, Time.deltaTime);

        if(dash)
        {
            stateMachine.ChangeState(CharacterBase.dashing);
            
        }
        if (lightAttack)
        {
            stateMachine.ChangeState(CharacterBase.lightAttacking);
        }     
        if (heavyAttack)
        {
            stateMachine.ChangeState(CharacterBase.heavyAttacking);
        }
        if(specialAttack)
        {
            stateMachine.ChangeState(CharacterBase.specialAttacking);
            CharacterBase.specialCharges = 0;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, CharacterBase.velocityDampTime);
  
        if (velocity == Vector3.zero)
        {
            currentVelocity = Vector3.zero;
        }
        CharacterBase.controller.Move(currentVelocity * Time.deltaTime * playerSpeed);

        CharacterBase.transform.rotation = Quaternion.Euler(new Vector3(0, -RotationAngle() + playerSyncWithPointer, 0));
    }

    float RotationAngle()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(CharacterBase.transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }


    public override void Exit()
    {
        base.Exit();

        CharacterBase.playerVelocity = new Vector3(input.x, 0, input.y);

    }
}
