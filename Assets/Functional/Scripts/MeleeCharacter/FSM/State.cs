using UnityEngine;
using UnityEngine.InputSystem;

public class State
{
    public CharacterVideo characterVideo;
    public StateMachine stateMachine;

    protected Vector3 velocity;
    protected Vector2 input;

    public InputAction moveAction;
    public InputAction dashAction;
    public InputAction attackAction;

    public State(CharacterVideo _character, StateMachine _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;

        moveAction = characterVideo.playerInput.actions["Move"];
        dashAction = characterVideo.playerInput.actions["Dash"];
        attackAction = characterVideo.playerInput.actions["Attack"];
    }

    public virtual void Enter()
    {
        Debug.Log("enter state: " + this.ToString());
    }

    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Exit()
    {
    }
}
