using UnityEngine;
using UnityEngine.InputSystem;

public class StandingState : State
{
    Vector3 currentVelocity;
    float playerSpeed;
    bool attack;
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

        attack = false;
        dash = false;
        input = Vector2.zero;
<<<<<<< Updated upstream
        velocity = new Vector3(5f, 0f, 5f);
        currentVelocity = new Vector3(5f,0f,5f);
        //gravityVelocity.y = 0;
=======
        velocity = Vector3.zero;
        currentVelocity = Vector3.zero;
>>>>>>> Stashed changes

        playerSpeed = characterVideo.playerSpeed;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (dashAction.triggered)
        {
            dash = true;
        }
        if (attackAction.triggered)
        {
            attack = true;
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
        if (attack)
        {
            stateMachine.ChangeState(characterVideo.attacking);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, characterVideo.velocityDampTime);
        Debug.Log(currentVelocity);
        if (velocity == Vector3.zero)
        {
            currentVelocity = Vector3.zero;
        }
        characterVideo.controller.Move(currentVelocity * Time.deltaTime * playerSpeed);

        characterVideo.transform.rotation = Quaternion.Euler(new Vector3(0, -RotationAngle(), 0));
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

        characterVideo.playerVelocity = new Vector3(input.x, 0, input.y);

    }
}
