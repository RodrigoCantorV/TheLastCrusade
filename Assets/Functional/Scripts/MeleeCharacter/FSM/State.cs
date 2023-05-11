using UnityEngine;
using UnityEngine.InputSystem;

public class State
{
    public CharacterBase characterVideo;
    public StateMachine stateMachine;

    protected Vector3 velocity;
    protected Vector2 input;

    public InputAction moveAction;
    public InputAction dashAction;
    public InputAction lightAttackAction;
    public InputAction heavyAttackAction;

    public State(CharacterBase _character, StateMachine _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;

        moveAction = characterVideo.playerInput.actions["Move"];
        dashAction = characterVideo.playerInput.actions["Dash"];
        lightAttackAction = characterVideo.playerInput.actions["LightAttack"];
        heavyAttackAction = characterVideo.playerInput.actions["HeavyAttack"];
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
