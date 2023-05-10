/*using UnityEngine;
public class SprintState : State
{
    float gravityValue;
    Vector3 currentVelocity;
 
    bool grounded;
    bool sprint;
    float playerSpeed;
    Vector3 cVelocity;

    public SprintState(CharacterVideo _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        sprint = false;
        input = Vector2.zero;
        velocity = Vector3.zero;
        currentVelocity = Vector3.zero;
        gravityVelocity.y = 0;
 
        playerSpeed = characterVideo.sprintSpeed;
        grounded = characterVideo.controller.isGrounded;
        gravityValue = characterVideo.gravityValue;        
    }
 
    public override void HandleInput()
    {
        base.Enter();
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);
 
        velocity = velocity.x * characterVideo.cameraTransform.right.normalized + velocity.z * characterVideo.cameraTransform.forward.normalized;
        velocity.y = 0f;
        if (sprintAction.triggered || input.sqrMagnitude == 0f)
        {
            sprint = false;
        }
        else
        {
            sprint = true;
        }
        /*if (jumpAction.triggered)
        {
            sprintJump = true;
 
        }
 
    }
 
    public override void LogicUpdate()
    {
        if (sprint)
        {
            characterVideo.animator.SetFloat("speed", input.magnitude + 0.5f, characterVideo.speedDampTime, Time.deltaTime);
        }
        else
        {
            stateMachine.ChangeState(characterVideo.standing);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = characterVideo.controller.isGrounded;
        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }
        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.velocityDampTime);
 
        characterVideo.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);
 
 
        if (velocity.sqrMagnitude > 0)
        {
            characterVideo.transform.rotation = Quaternion.Slerp(characterVideo.transform.rotation, Quaternion.LookRotation(velocity), characterVideo.rotationDampTime);
        }
    }
}*/
