using UnityEngine;
using UnityEngine.InputSystem;
public class AttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;

    bool leftClick;
    bool rightClick;

    public AttackState(CharacterVideo _characterVideo, StateMachine _stateMachine) : base(_characterVideo, _stateMachine)
    {
        characterVideo = _characterVideo;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        leftClick = false;
        rightClick = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();

        var mouse = Mouse.current;

        // Verificar si se presionó el botón izquierdo del mouse
        if (mouse.leftButton.isPressed)
        {
            leftClick = true;
        }
        // Verificar si se presionó el botón derecho del mouse
        else if (mouse.rightButton.isPressed)
        {
            rightClick = true;
        }

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (leftClick)
        {
            characterVideo.animator.SetTrigger("lightAttack");
        }
        if (rightClick)
        {
            characterVideo.animator.SetTrigger("heavyAttack");
        }
        
        timePassed += Time.deltaTime;
        clipLength = characterVideo.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = characterVideo.animator.GetCurrentAnimatorStateInfo(0).speed;

        Debug.Log(clipLength);
        Debug.Log(clipSpeed);
        if (timePassed >= clipLength / clipSpeed)
        {
            Debug.Log("Que Hizo Ñero");
            stateMachine.ChangeState(characterVideo.movement);
            characterVideo.animator.SetTrigger("move");
        }
    }

    public override void Exit()
    {
        base.Exit();
        timePassed = 0f;
    }
}