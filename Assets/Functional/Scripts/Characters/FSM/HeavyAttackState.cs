using UnityEngine;
using UnityEngine.InputSystem;
public class HeavyAttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;

    bool attack;


    public HeavyAttackState(CharacterBase _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
    {
        CharacterBase = _characterVideo;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        attack=true;
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        base.LogicUpdate();


        timePassed += Time.deltaTime;


        clipLength = FindAnimation(CharacterBase.animator, CharacterBase.heavyAttackAnimationName).length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;

        if (timePassed < clipLength / clipSpeed && attack)
        {
            CharacterBase.animator.SetTrigger("heavyAttack");
            attack = false;
        }


        if (timePassed > clipLength / clipSpeed)
        {
            stateMachine.ChangeState(CharacterBase.movement);
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

    public override void Exit()
    {
        base.Exit();
        CharacterBase.animator.SetTrigger("move");
        timePassed = 0f;
    }
}