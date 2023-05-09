//using UnityEngine;
//public class CombatState : State
//{
//    float gravityValue;
//    Vector3 currentVelocity;
//    bool grounded;
//    bool sheathWeapon;
//    float playerSpeed;
//    bool attack;
 
//    Vector3 cVelocity;
 
//    public CombatState(CharacterVideo _character, StateMachine _stateMachine) : base(_character, _stateMachine)
//    {
//        characterVideo = _character;
//        stateMachine = _stateMachine;
//    }
 
//    public override void Enter()
//    {
//        base.Enter();
 
//        sheathWeapon = false;
//        input = Vector2.zero;
//        currentVelocity = Vector3.zero;
//        gravityVelocity.y = 0;
//        attack = false;
 
//        velocity = characterVideo.playerVelocity;
//        playerSpeed = characterVideo.playerSpeed;
//        grounded = characterVideo.controller.isGrounded;
//        gravityValue = characterVideo.gravityValue;
//    }
 
//    public override void HandleInput()
//    {
//        base.HandleInput();
 
//        if (drawWeaponAction.triggered)
//        {
//            sheathWeapon = true;
//        }
 
//        if (attackAction.triggered)
//        {
//            attack = true;
//        }
 
//        input = moveAction.ReadValue<Vector2>();
//        velocity = new Vector3(input.x, 0, input.y);
 
//        velocity = velocity.x * characterVideo.cameraTransform.right.normalized + velocity.z * characterVideo.cameraTransform.forward.normalized;
//        velocity.y = 0f;
 
//    }
 
//    public override void LogicUpdate()
//    {
//        base.LogicUpdate();
 
//        characterVideo.animator.SetFloat("speed", input.magnitude, characterVideo.speedDampTime, Time.deltaTime);
 
//        if (sheathWeapon)
//        {
//            characterVideo.animator.SetTrigger("sheathWeapon");
//            stateMachine.ChangeState(characterVideo.standing);
//        }
 
//        if (attack)
//        {
//            characterVideo.animator.SetTrigger("attack");
//            stateMachine.ChangeState(characterVideo.attacking);
//        }
//    }
 
//    public override void PhysicsUpdate()
//    {
//        base.PhysicsUpdate();
 
//        gravityVelocity.y += gravityValue * Time.deltaTime;
//        grounded = characterVideo.controller.isGrounded;
 
//        if (grounded && gravityVelocity.y < 0)
//        {
//            gravityVelocity.y = 0f;
//        }
 
//        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.velocityDampTime);
//        characterVideo.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);
 
//        if (velocity.sqrMagnitude > 0)
//        {
//            characterVideo.transform.rotation = Quaternion.Slerp(characterVideo.transform.rotation, Quaternion.LookRotation(velocity), characterVideo.rotationDampTime);
//        }
 
//    }
 
//    public override void Exit()
//    {
//        base.Exit();
 
//        gravityVelocity.y = 0f;
//        characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);
 
//        if (velocity.sqrMagnitude > 0)
//        {
//            characterVideo.transform.rotation = Quaternion.LookRotation(velocity);
//        }
 
//    }
 
//}
