using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterBase : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed;
    public float dashSpeed;
    public float life;
    
    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float delayAnimationTime = 0f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    public float lightAttackDamage;
    public float heavyAttackDamage;

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
    [HideInInspector]
    public string dashAnimationName, heavyAttackAnimationName, lightAttackAnimationName;

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
    protected virtual void StartDealDamageLightAttack()
    {        
    }
    protected virtual void EndDealDamageLightAttack()
    {
    }

    protected virtual void StartDealDamageHeavyAttack()
    {        
    }
    protected virtual void EndDealDamageHeavyAttack()
    {
    }

    public void TakeDamage(float damageAmount)
    {
        life -= damageAmount;
        //animator.SetTrigger("damage");
        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("se muertio");
        //Destroy(this.gameObject);
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
