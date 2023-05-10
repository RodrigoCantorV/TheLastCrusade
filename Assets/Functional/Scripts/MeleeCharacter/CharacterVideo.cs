using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterVideo : MonoBehaviour
{
    [Header("Controls")]
<<<<<<< Updated upstream


    public float playerSpeed = 5.0f;
    public float dashSpeed = 5.0f;

    //public float gravityMultiplier = 2;
    //public float rotationSpeed = 5f;
 
=======
    public float playerSpeed = 7.0f;
    public float dashSpeed = 10.0f;
    
>>>>>>> Stashed changes
    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float delayAnimationTime = 0f;
    [Range(0, 1)]
<<<<<<< Updated upstream



    public float velocityDampTime = 0f;

    //[Range(0, 1)]
    //public float rotationDampTime = 0.2f;
    //[Range(0, 1)]
    //public float airControl = 0.5f;
=======
    public float velocityDampTime = 0.9f;
>>>>>>> Stashed changes

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
