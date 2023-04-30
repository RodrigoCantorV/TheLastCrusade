using UnityEngine;
using UnityEngine.InputSystem;
 
public class State
{
    public CharacterVideo characterVideo;
    public StateMachine stateMachine;
 
    protected Vector3 gravityVelocity;
    protected Vector3 velocity;
    protected Vector2 input;
 
    public InputAction moveAction;
    public InputAction crouchAction;
    public InputAction sprintAction;
    public InputAction drawWeaponAction;
    public InputAction attackAction;
 
    public State(CharacterVideo _character, StateMachine _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
 
        moveAction = characterVideo.playerInput.actions["Move"];
        crouchAction = characterVideo.playerInput.actions["Crouch"];
        sprintAction = characterVideo.playerInput.actions["Sprint"];
        drawWeaponAction = characterVideo.playerInput.actions["DrawWeapon"];
        attackAction = characterVideo.playerInput.actions["Attack"];
 
    }
 
    public virtual void Enter()
    {
        Debug.Log("enter state: "+this.ToString());
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
