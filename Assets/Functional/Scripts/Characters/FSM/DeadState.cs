using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{  
    public DeadState(CharacterBase _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        CharacterBase = _character;
        stateMachine = _stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        CharacterBase.animator.SetBool("dead", true);
    }
}

