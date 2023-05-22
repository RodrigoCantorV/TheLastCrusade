using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed;
    public float dashSpeed;
    public float life;

    public Image lifeBar;
    public GameObject lifeeBar;
    public float maxLife;

    [Header("Animation Smoothing")]
    [Range(0, 1)]
    public float delayAnimationTime = 0f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    public float lightAttackDamage;
    public float heavyAttackDamage;
    public float specialAttackDamage;

    public StateMachine movementSM;
    public StandingState movement;
    public DashState dashing;
    public HeavyAttackState heavyAttacking;
    public LightAttackState lightAttacking;
    public SpecialAttackState specialAttacking;

    [HideInInspector]
    public MenuGamePlay menuGamePlay;

    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public Vector3 playerVelocity;
    [HideInInspector]

    public string dashAnimationName, heavyAttackAnimationName, lightAttackAnimationName, specialAttackAnimationName, hurtAnimationName, deadAnimationName;
    [HideInInspector]
    public float playerSyncWithPointer = 90f;
    public bool estaAfuera;
    public bool estaVivo;

    void Awake() 
    {
        maxLife = 160;
        lifeeBar = GameObject.Find("LifeBar");
        lifeBar = lifeeBar.GetComponent<Image>();
    }

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
        specialAttacking = new SpecialAttackState(this, movementSM);

        movementSM.Initialize(movement);

        menuGamePlay = GetComponent<MenuGamePlay>();
        //StartCoroutine(menuGamePlay.GameOver());
        menuGamePlay = FindObjectOfType<MenuGamePlay>();
        estaVivo = true;
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

    protected virtual void StartDealDamageSpecialAttack()
    {        
    }
    protected virtual void EndDealDamageSpecialAttack()
    {
    }


    public void TakeDamage(float damageAmount)
    {
        life -= damageAmount;
        animator.SetBool("damage", true);
        LifeManagement();
        if (life <= 0)
        {
            Die();
            if (menuGamePlay != null)
            {
                StartCoroutine(menuGamePlay.GameOver());
                //menuGamePlay.GameOver();
            }
        }
        //animator.SetTrigger("move");
    }

    public void LifeManagement()
    {
        //lifeBar.GetComponent<Image>().fillAmount = life / maxLife;
        lifeBar.fillAmount = life / maxLife;
        Debug.Log("resta vidaa");
    }

    void Die()
    {
        estaVivo = false;
        // se ejecuta animacion dead
        animator.SetBool("dead", true);
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
    public float RotationAngle()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Wall2"))
        {
            estaAfuera = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Wall2"))
        {
            estaAfuera = false;
        }
    }
}
