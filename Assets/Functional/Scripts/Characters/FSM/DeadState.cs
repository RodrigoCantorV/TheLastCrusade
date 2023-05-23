using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    // Start is called before the first frame update
    public DeadState(CharacterBase _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        CharacterBase = _character;
        stateMachine = _stateMachine;

    }

    // Update is called once per frame
    public override void Enter()
    {
        base.Enter();
        CharacterBase.animator.SetBool("dead", true);
    }
}

