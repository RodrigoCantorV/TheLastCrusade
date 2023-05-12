using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterBase : MonoBehaviour
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
    public HeavyAttackState heavyAttacking;

    public LightAttackState lightAttacking;

    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Animator animator;
    // [HideInInspector]
    // public DamageDealer dealer;
    [HideInInspector]
    public Vector3 playerVelocity;
    public string hola;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        //dealer = GetComponentInChildren<DamageDealer>();

        movementSM = new StateMachine();
        movement = new StandingState(this, movementSM);
        dashing = new DashState(this, movementSM);
        heavyAttacking = new HeavyAttackState(this, movementSM);
        lightAttacking = new LightAttackState(this, movementSM);

        movementSM.Initialize(movement);
    }
    void StartDealDamage()
    {
        GetComponentInChildren<DamageDealer>().StartDealDamage();      
    }
     void EndDealDamage()
    {
        GetComponentInChildren<DamageDealer>().EndDealDamage();
    }
 
    protected void Update()
    {
        movementSM.currentState.HandleInput(); 
        movementSM.currentState.LogicUpdate();
    }
 
    protected void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}
