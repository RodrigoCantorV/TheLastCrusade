using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterVideo : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed = 7.0f;
    public float dashSpeed = 10.0f;
    
    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float delayAnimationTime = 0f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;

    public StateMachine movementSM;
    public StandingState movement;
    public DashState dashing;
    public AttackState attacking;
 
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Vector3 playerVelocity;
 
 
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
 
        movementSM = new StateMachine();
        movement = new StandingState(this, movementSM);
        dashing = new DashState(this, movementSM);
        attacking = new AttackState(this, movementSM);
 
        movementSM.Initialize(movement);
    }
 
    private void Update()
    {
        movementSM.currentState.HandleInput(); 
        movementSM.currentState.LogicUpdate();
    }
 
    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}
