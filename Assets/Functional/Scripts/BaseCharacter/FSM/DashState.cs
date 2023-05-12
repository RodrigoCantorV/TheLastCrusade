
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
        CharacterBase = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        heavyAttack = false;
        lightAttack = false;
        CharacterBase.animator.SetTrigger("dash");     
        dashSpeed = CharacterBase.dashSpeed;
      //  currentVelocity = Vector3.zero;
        velocity = new Vector3(input.x, 0, input.y);
        velocity = velocity.x * CharacterBase.transform.right.normalized + velocity.z * CharacterBase.transform.forward.normalized;
      
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

    public AnimationClip FindAnimation(Animator animator, string name)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (lightAttack)
        {
            Debug.Log("Ajuaaaa");
            stateMachine.ChangeState(CharacterBase.lightAttacking);
        }
        if (heavyAttack)
        {
            stateMachine.ChangeState(CharacterBase.heavyAttacking);
        }

        timePassed += Time.deltaTime;
        clipLength = FindAnimation(CharacterBase.animator, "Dash").length;

        //clipLength = CharacterBase.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;
   


        if (timePassed >= clipLength / clipSpeed)
        {
            Debug.Log("añoño");
            stateMachine.ChangeState(CharacterBase.movement);
            CharacterBase.animator.SetTrigger("move");
            //dash = false;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.dashDampTime);
        if (velocity == Vector3.zero)
        {
            velocity = CharacterBase.transform.right;
        }

        //Debug.Log(dashSpeed);
        //Debug.Log(velocity  * dashSpeed * Time.deltaTime);

     
        CharacterBase.controller.Move(velocity * dashSpeed * Time.deltaTime);
        
      
        
    }

    public override void Exit()
    {
        base.Exit();
       
        //characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);
        CharacterBase.animator.SetTrigger("move");
        timePassed = 0f;
    }
}
