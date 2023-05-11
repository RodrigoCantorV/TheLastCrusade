using UnityEngine;
using UnityEngine.InputSystem;
public class LightAttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    public LightAttackState(CharacterBase _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
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

      

        // Verificar si se presionó el botón izquierdo del mouse


    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        timePassed += Time.deltaTime;


        clipLength = FindAnimation(CharacterBase.animator, "combat_attack").length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;

        if (timePassed <= clipLength / clipSpeed && attack)
        {
            
            CharacterBase.animator.SetTrigger("lightAttack");
            attack = false;
        }        

    
        if (timePassed >= clipLength / clipSpeed)
        {
           
            stateMachine.ChangeState(CharacterBase.movement);
            
            CharacterBase.animator.SetTrigger("move");
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