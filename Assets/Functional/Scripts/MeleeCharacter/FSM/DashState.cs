using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    float dashSpeed;
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool dash;
    Vector3 currentVelocity;

    public DashState(CharacterVideo _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        characterVideo.animator.SetTrigger("dash");
        dash = false;
        dashSpeed = characterVideo.dashSpeed;
        currentVelocity = Vector3.zero;
        //timePassed = 0f;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        //input = dashAction.ReadValue<Vector2>();
        if(dashAction.triggered)
        {
            dash = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //if (dash)
        //{
        //    characterVideo.animator.SetFloat("speed", input.magnitude + 0.5f, characterVideo.speedDampTime, Time.deltaTime);
        //}
        //else
        //{
        //    stateMachine.ChangeState(characterVideo.movement);
        //}

        timePassed += Time.deltaTime;
        clipLength = characterVideo.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = characterVideo.animator.GetCurrentAnimatorStateInfo(0).speed;

        if (timePassed >= clipLength / clipSpeed && dash)
        {
            stateMachine.ChangeState(characterVideo.dashing);
        }
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
        currentVelocity = Vector3.forward;
        characterVideo.controller.Move(currentVelocity * dashSpeed);
    }

    public override void Exit()
    {
        base.Exit();
        //characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);
        characterVideo.animator.SetTrigger("move");
        timePassed = 0f;
    }
}
