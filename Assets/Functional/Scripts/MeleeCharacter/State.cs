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
    //public InputAction lookAction;
    //public InputAction jumpAction;
    public InputAction crouchAction;
    public InputAction sprintAction;
 
    public State(CharacterVideo _character, StateMachine _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
 
        moveAction = characterVideo.playerInput.actions["Move"];
        // = characterVideo.playerInput.actions["Look"];
        // = characterVideo.playerInput.actions["Jump"];
        crouchAction = characterVideo.playerInput.actions["Crouch"];
        sprintAction = characterVideo.playerInput.actions["Sprint"];
 
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
