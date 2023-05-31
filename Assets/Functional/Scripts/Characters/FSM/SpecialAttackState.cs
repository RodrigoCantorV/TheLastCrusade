using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    public SpecialAttackState(CharacterBase _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
    {
        CharacterBase = _characterVideo;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        attack = true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        clipLength = FindAnimation(CharacterBase.animator, CharacterBase.specialAttackAnimationName).length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;

        if (timePassed < clipLength / clipSpeed && attack)
        {
            CharacterBase.animator.SetTrigger("specialAttack");
            attack = false;
        }

        if (timePassed > clipLength / clipSpeed)
        {
            stateMachine.ChangeState(CharacterBase.movement);
        }
        if (CharacterBase.ToString() == "DistanceCharacter(Clone) (DistanceCharacter)") 
        {
            CharacterBase.transform.rotation = Quaternion.Euler(new Vector3(0, -CharacterBase.RotationAngle() + CharacterBase.playerSyncWithPointer, 0));
        }
    }




    public override void Exit()
    {
        base.Exit();
        CharacterBase.PowerupManagement();
        //CharacterBase.animator.SetTrigger("move");
        timePassed = 0f;
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
}

