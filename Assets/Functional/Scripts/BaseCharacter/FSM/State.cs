using UnityEngine;
using UnityEngine.InputSystem;

public class State
{
    public CharacterBase CharacterBase;
    public StateMachine stateMachine;

    protected Vector3 velocity;
    protected Vector2 input;

    public InputAction moveAction;
    public InputAction dashAction;
    public InputAction lightAttackAction;
    public InputAction heavyAttackAction;

    public State(CharacterBase _character, StateMachine _stateMachine)
    {
        CharacterBase = _character;
        stateMachine = _stateMachine;

        moveAction = CharacterBase.playerInput.actions["Move"];
        dashAction = CharacterBase.playerInput.actions["Dash"];
        lightAttackAction = CharacterBase.playerInput.actions["LightAttack"];
        heavyAttackAction = CharacterBase.playerInput.actions["HeavyAttack"];
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

    // public virtual void StartDealDamage()
    // {          
    // }
    // public virtual void EndDealDamage()
    // {
    // }

    public virtual void Exit()
    {
    }
}
