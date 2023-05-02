using UnityEngine;
public class AttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    public AttackState(CharacterVideo _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
    {
        characterVideo = _characterVideo;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        attack = false;
        characterVideo.animator.applyRootMotion = true;
        timePassed = 0f;
        characterVideo.animator.SetTrigger("attack");
        characterVideo.animator.SetFloat("speed", 0f);
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
 
        if (attackAction.triggered)
        {
            attack = true;
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
 
        timePassed += Time.deltaTime;
        clipLength = characterVideo.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = characterVideo.animator.GetCurrentAnimatorStateInfo(1).speed;
 
        if (timePassed >= clipLength / clipSpeed && attack)
        {
            stateMachine.ChangeState(characterVideo.attacking);
        }
        if (timePassed >= clipLength / clipSpeed)
        {
            stateMachine.ChangeState(characterVideo.combatting);
            characterVideo.animator.SetTrigger("move");
        }
 
    }
    public override void Exit()
    {
        base.Exit();
        characterVideo.animator.applyRootMotion = false;
    }
}