
using UnityEngine;
using UnityEngine.InputSystem;

public class DashState : State
{
    float dashSpeed;
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool heavyAttack, lightAttack;

    // Vector3 currentVelocity;
    // Vector3 cVelocity;



    public DashState(CharacterBase _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        heavyAttack = false;
        lightAttack = false;
        characterVideo.animator.SetTrigger("dash");     
        dashSpeed = characterVideo.dashSpeed;
      //  currentVelocity = Vector3.zero;
        velocity = new Vector3(input.x, 0, input.y);
        velocity = velocity.x * characterVideo.transform.right.normalized + velocity.z * characterVideo.transform.forward.normalized;
      
        //timePassed = 0f;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        //input = dashAction.ReadValue<Vector2>();
        //if(dashAction.triggered)
        //{
        //    Debug.Log("aqui");
        //    dash = true;
        //}
        if (lightAttackAction.triggered)
        {
            lightAttack = true;

        }
        if (heavyAttackAction.triggered)
        {
            heavyAttack = true;

        }


    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (lightAttack)
        {
            stateMachine.ChangeState(characterVideo.lightAttacking);
        }
        if (heavyAttack)
        {
            stateMachine.ChangeState(characterVideo.heavyAttacking);
        }

        timePassed += Time.deltaTime;
        clipLength = characterVideo.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = characterVideo.animator.GetCurrentAnimatorStateInfo(0).speed;
   


        if (timePassed >= clipLength / clipSpeed)
        {
            
            stateMachine.ChangeState(characterVideo.movement);
            characterVideo.animator.SetTrigger("move");
            //dash = false;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.dashDampTime);
        if (velocity == Vector3.zero)
        {
            velocity = characterVideo.transform.forward;
        }

        Debug.Log(dashSpeed);
        Debug.Log(velocity  * dashSpeed * Time.deltaTime);

     
        characterVideo.controller.Move(velocity * dashSpeed * Time.deltaTime);
        
      
        
    }

    public override void Exit()
    {
        base.Exit();
       
        //characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);
        //characterVideo.animator.SetTrigger("move");
        timePassed = 0f;
    }
}
