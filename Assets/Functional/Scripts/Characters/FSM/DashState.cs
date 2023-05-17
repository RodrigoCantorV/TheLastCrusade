
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
        
        //timePassed = 0f;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * CharacterBase.transform.right.normalized + velocity.z * CharacterBase.transform.forward.normalized;
        Debug.Log("velocidad de entrada: " + velocity);


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
            stateMachine.ChangeState(CharacterBase.lightAttacking);
        }
        if (heavyAttack)
        {
            stateMachine.ChangeState(CharacterBase.heavyAttacking);
        }

        timePassed += Time.deltaTime;
        clipLength = FindAnimation(CharacterBase.animator, CharacterBase.dashAnimationName).length;

        //clipLength = CharacterBase.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;
   


        if (timePassed >= clipLength / clipSpeed)
        {        
            stateMachine.ChangeState(CharacterBase.movement);
            CharacterBase.animator.SetTrigger("move");
            //dash = false;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Debug.Log(velocity);
        //if (velocity == Vector3.zero)
        //{
        //    Debug.Log("hola?");
        velocity = CharacterBase.transform.forward;
        //}

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
