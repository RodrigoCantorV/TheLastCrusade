using UnityEngine;
using UnityEngine.InputSystem;
public class LightAttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;    
    public LightAttackState(CharacterBase _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
    {
        CharacterBase = _characterVideo;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterBase.animator.SetTrigger("lightAttack");        
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        timePassed += Time.deltaTime;
        clipLength = FindAnimation(CharacterBase.animator, CharacterBase.lightAttackAnimationName).length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;

        
             
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