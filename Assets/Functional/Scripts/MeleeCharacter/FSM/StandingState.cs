using UnityEngine;

public class StandingState : State
{

    //float gravityValue;
    //bool jump;   
    //bool crouch;
    Vector3 currentVelocity;
    //bool grounded;
    //bool sprint;
    float playerSpeed;
    //bool drawWeapon;
    bool dash;

    Vector3 cVelocity;

    public StandingState(CharacterVideo _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        characterVideo = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        //crouch = false;
        //sprint = false;
        //drawWeapon = false;
        dash = false;
        input = Vector2.zero;
        velocity = new Vector3(5f, 0f, 5f);
        currentVelocity = new Vector3(5f,0f,5f);
        //gravityVelocity.y = 0;

        playerSpeed = characterVideo.playerSpeed;
        //grounded = characterVideo.controller.isGrounded;
        //gravityValue = characterVideo.gravityValue;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        //if (crouchAction.triggered)
        //{
        //    crouch = true;
        //}
        //if (sprintAction.triggered)
        //{
        //    sprint = true;
        //}
        //if (drawWeaponAction.triggered)
        //{
        //    drawWeapon = true;
        //}
        if(dashAction.triggered)
        {
            dash = true;
        }
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * characterVideo.transform.right.normalized + velocity.z * characterVideo.transform.forward.normalized;
        velocity.y = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        characterVideo.animator.SetFloat("speed", input.magnitude, characterVideo.delayAnimationTime, Time.deltaTime);

        if(dash)
        {
            stateMachine.ChangeState(characterVideo.dashing);
            //characterVideo.animator.SetTrigger("dashTrigger");
        }
        //if (sprint)
        //{
        //    stateMachine.ChangeState(characterVideo.sprinting);
        //}
        //if (crouch)
        //{
        //    stateMachine.ChangeState(characterVideo.crouching);
        //}
        //if (drawWeapon)
        //{
        //    stateMachine.ChangeState(characterVideo.combatting);
        //    characterVideo.animator.SetTrigger("drawWeapon");
        //}

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        //gravityVelocity.y += gravityValue * Time.deltaTime;
        //grounded = characterVideo.controller.isGrounded;

        //if (grounded && gravityVelocity.y < 0)
        //{
        //    gravityVelocity.y = 0f;
        //}

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.velocityDampTime);
        Debug.Log(currentVelocity);
        if (velocity == Vector3.zero)
        {
            currentVelocity = Vector3.zero;
        }
        characterVideo.controller.Move(currentVelocity * Time.deltaTime * playerSpeed);

        characterVideo.transform.rotation = Quaternion.Euler(new Vector3(0, -RotationAngle(), 0));

        //if (velocity.sqrMagnitude > 0)
        //{
        //    characterVideo.transform.rotation = Quaternion.Slerp(characterVideo.transform.rotation, Quaternion.Euler(new Vector3(0, -RotationAngle(), 0)), characterVideo.rotationDampTime);
        //}
    }

    float RotationAngle()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(characterVideo.transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }


    public override void Exit()
    {
        base.Exit();

        //gravityVelocity.y = 0f;
        characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);

        //if (velocity.sqrMagnitude > 0)
        //{
        //    characterVideo.transform.rotation = Quaternion.LookRotation(velocity);
        //}
    }
}
