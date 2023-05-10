using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterVideo : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed = 5.0f;
    public float dashSpeed = 5.0f;
    //public float gravityMultiplier = 2;
    //public float rotationSpeed = 5f;
 
    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float delayAnimationTime = 0f;
    [Range(0, 1)]
    public float velocityDampTime = 0f;
    //[Range(0, 1)]
    //public float rotationDampTime = 0.2f;
    //[Range(0, 1)]
    //public float airControl = 0.5f;

    public StateMachine movementSM;
    public StandingState movement;
    public DashState dashing;
    //public CrouchingState crouching;
    //public SprintState sprinting;
    //public CombatState combatting;
    //public AttackState attacking;
 
    //[HideInInspector]
    //public float gravityValue = -9.81f;
    //[HideInInspector]
    //public float normalColliderHeight;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public PlayerInput playerInput;
   // [HideInInspector]
   // public Transform cameraTransform;
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
        //cameraTransform = Camera.main.transform;
 
        movementSM = new StateMachine();
        movement = new StandingState(this, movementSM);
        dashing = new DashState(this, movementSM);
        //crouching = new CrouchingState(this, movementSM);
        //sprinting = new SprintState(this, movementSM);
        //combatting = new CombatState(this, movementSM);
        //attacking = new AttackState(this, movementSM);
 
        movementSM.Initialize(movement);
 
        //normalColliderHeight = controller.height;
        //gravityValue *= gravityMultiplier;
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
