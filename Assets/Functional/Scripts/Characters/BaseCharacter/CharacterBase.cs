using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed;
    public float dashSpeed;
    public float life;

    float alphaRef;
    Color color;

    private float targetAlpha = 0f;
    private float currentVelocity;
    public float fadeTime = 0.1f;

    [SerializeField] private float fadeDuration = 2f;

    private bool isFading = false; // Variable para controlar si la imagen está desvaneciéndose

    [HideInInspector] protected Image lifeBar;
    public float maxLife;

    [SerializeField] protected Image levelAttackk;
    [SerializeField] protected Image hardAttackk;
    [SerializeField] protected Image fatalAttackk;

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
        //lifeeBar = GameObject.Find("LifeBar");
        lifeBar = GameObject.Find("LifeBar").GetComponent<Image>();
        levelAttackk = GameObject.Find("LevelAttack").GetComponent<Image>();
        hardAttackk = GameObject.Find("HardAttack").GetComponent<Image>();
        fatalAttackk = GameObject.Find("FatalAttack").GetComponent<Image>();
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

    protected void ActivarImagen(int cantidad)
    {

        fadeTime = 0f;
        isFading = false;

        if (cantidad > 120 && cantidad <= 140)
        {
            targetAlpha = 1f;
            levelAttackk.gameObject.SetActive(true);
            Debug.Log("Damage LevelAttack");
        }
        else if (cantidad >= 80 && cantidad <= 100)
        {
            levelAttackk.gameObject.SetActive(false);
            targetAlpha = 1f;
            hardAttackk.gameObject.SetActive(true);
            Debug.Log("HardAttack");
        }
        else if (cantidad >= 20 && cantidad <= 40)
        {
            hardAttackk.gameObject.SetActive(false);
            targetAlpha = 1f;
            fatalAttackk.gameObject.SetActive(true);
            Debug.Log("FatalAttack");
        }
        else
        {
            targetAlpha = 0f; // Establecer el valor de alpha a 0 si no se cumple ninguna condición
        }

        if (targetAlpha == 1f)
        {
            // Si la imagen se activa, inicia el temporizador de desvanecimiento
            isFading = true;
            fadeTime = fadeDuration;
        }

    }


    public void TakeDamage(float damageAmount)
    {
        life -= damageAmount;
        animator.SetTrigger("damage");
        ActivarImagen(Mathf.CeilToInt(life));
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
        UpdateAlpha();
    }

    private void UpdateAlpha()
{
    float alpha = Mathf.SmoothDamp(levelAttackk.color.a, targetAlpha, ref currentVelocity, fadeDuration);
    Color levelAttackColor = levelAttackk.color;
    levelAttackColor.a = alpha;
    levelAttackk.color = levelAttackColor;

    alpha = Mathf.SmoothDamp(hardAttackk.color.a, targetAlpha, ref currentVelocity, fadeDuration);
    Color hardAttackColor = hardAttackk.color;
    hardAttackColor.a = alpha;
    hardAttackk.color = hardAttackColor;

    alpha = Mathf.SmoothDamp(fatalAttackk.color.a, targetAlpha, ref currentVelocity, fadeDuration);
    Color fatalAttackColor = fatalAttackk.color;
    fatalAttackColor.a = alpha;
    fatalAttackk.color = fatalAttackColor;

    // Desactivar las imágenes cuando alcanzan un valor de alpha cercano a 0
    if (Mathf.Abs(alpha - targetAlpha) < 0.01f)
    {
        if (targetAlpha == 0f)
        {
            levelAttackk.gameObject.SetActive(false);
            hardAttackk.gameObject.SetActive(false);
            fatalAttackk.gameObject.SetActive(false);
        }
    }

    if (isFading)
    {
        fadeTime -= Time.deltaTime * 2;

        if (fadeTime <= 0f)
        {
            // Si el temporizador ha alcanzado cero, comienza a desvanecer la imagen
            targetAlpha = 0f;
            isFading = false;
        }
    }
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
