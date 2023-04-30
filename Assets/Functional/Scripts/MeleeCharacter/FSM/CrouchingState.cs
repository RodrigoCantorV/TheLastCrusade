using UnityEngine;
 
public class CrouchingState : State
{
    float playerSpeed;
    bool belowCeiling;
    bool crouchHeld;
 
    bool grounded;
    float gravityValue;
    Vector3 currentVelocity;
 
 
    public CrouchingState(CharacterVideo _character, StateMachine _stateMachine):base(_character, _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        characterVideo.animator.SetTrigger("crouch");  
        belowCeiling = false;
        crouchHeld = false;
        gravityVelocity.y = 0;
 
        playerSpeed = characterVideo.crouchSpeed;
        characterVideo.controller.height = characterVideo.crouchColliderHeight;
        characterVideo.controller.center = new Vector3(0f, characterVideo.crouchColliderHeight / 2f, 0f);
        grounded = characterVideo.controller.isGrounded;
        gravityValue = characterVideo.gravityValue;
 
        
    }
 
    public override void Exit()
    {
        base.Exit();
        characterVideo.controller.height = characterVideo.normalColliderHeight;
        characterVideo.controller.center = new Vector3(0f, characterVideo.normalColliderHeight / 2f, 0f);
        gravityVelocity.y = 0f;
        characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);
        characterVideo.animator.SetTrigger("move");
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
        if (crouchAction.triggered && !belowCeiling)
        {
            crouchHeld = true;
        }
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);
 
        velocity = velocity.x * characterVideo.cameraTransform.right.normalized + velocity.z * characterVideo.cameraTransform.forward.normalized;
        velocity.y = 0f;
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        characterVideo.animator.SetFloat("speed", input.magnitude, characterVideo.speedDampTime, Time.deltaTime);
 
        if (crouchHeld)
        {
            stateMachine.ChangeState(characterVideo.standing);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        belowCeiling = CheckCollisionOverlap(characterVideo.transform.position + Vector3.up * characterVideo.normalColliderHeight);
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = characterVideo.controller.isGrounded;
        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }
        currentVelocity = Vector3.Lerp(currentVelocity, velocity, characterVideo.velocityDampTime);
 
        characterVideo.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);
 
        if (velocity.magnitude > 0)
        {
            characterVideo.transform.rotation = Quaternion.Slerp(characterVideo.transform.rotation, Quaternion.LookRotation(velocity), characterVideo.rotationDampTime);
        }
    }
 
    public bool CheckCollisionOverlap(Vector3 targetPositon)
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit hit;
 
        Vector3 direction = targetPositon - characterVideo.transform.position;
        if (Physics.Raycast(characterVideo.transform.position, direction, out hit, characterVideo.normalColliderHeight, layerMask))
        {
            Debug.DrawRay(characterVideo.transform.position, direction * hit.distance, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(characterVideo.transform.position, direction * characterVideo.normalColliderHeight, Color.white);
            return false;
        }       
    }
}
