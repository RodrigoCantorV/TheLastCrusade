using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
    bool heavyAttack, lightAttack, dash, specialAttack;
    float timePassed;
    float clipLength;
    float clipSpeed;
    public HurtState(CharacterBase _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        CharacterBase = _character;
        stateMachine = _stateMachine;
    }

    // Start is called before the first frame update

    public override void Enter()
    {
        base.Enter();

        heavyAttack = false;
        lightAttack = false;
        specialAttack = false;
        dash = false;
        CharacterBase.animator.SetTrigger("damage");
        //CharacterBase.vulnerable = false;

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
        if (specialAttackAction.triggered && CharacterBase.specialCharges >= 3)
        {
            specialAttack = true;
        }

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        

        timePassed += Time.deltaTime;
        clipLength = FindAnimation(CharacterBase.animator, CharacterBase.hurtAnimationName).length;
        clipSpeed = CharacterBase.animator.GetCurrentAnimatorStateInfo(0).speed;

        if (timePassed >= clipLength / clipSpeed)
        {
            if (dash)
            {
                stateMachine.ChangeState(CharacterBase.dashing);
            }
            Debug.Log("light:" +lightAttack);
            if (lightAttack)
            {
                stateMachine.ChangeState(CharacterBase.lightAttacking);
                Debug.Log("Perro");
            }
            else if (heavyAttack)
            {
                stateMachine.ChangeState(CharacterBase.heavyAttacking);
            }
            else if (specialAttack)
            {
                stateMachine.ChangeState(CharacterBase.specialAttacking);
                CharacterBase.specialCharges = 0;
            }
            else if (!CharacterBase.isAlive)
            {
                stateMachine.ChangeState(CharacterBase.deadState);
            }
            else
            {
                stateMachine.ChangeState(CharacterBase.movement);
                CharacterBase.animator.SetTrigger("move");
            }
            
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
        //CharacterBase.animator.SetFloat("speed", 1f);
        timePassed = 0f;
        //CharacterBase.vulnerable = true;
    }
}
