using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterBase : MonoBehaviour
{
    [Header("Controls")]
    public float playerSpeed;
    public float dashSpeed;
    public float life;


    private float targetAlpha = 0f;
    private float currentVelocity;
    public float fadeTime = 0.1f;

    [SerializeField] private float fadeDuration = 0.5f;

    public float fadeTimer = 0f;

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
    public DeadState deadState;

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
    public bool isAlive=true;

    public float specialCharges;
    [HideInInspector] protected Image powerupBar;
    public float powrupCharge = 0.4f;


    // SONIDOS

    public AudioSource audioSource;
    public AudioClip lightAttackSound;
    public AudioClip hardAttackSound;
    public AudioClip ultiSound;

    void Awake() 
    {
        maxLife = 160;
        //lifeeBar = GameObject.Find("LifeBar");
        lifeBar = GameObject.Find("LifeBar").GetComponent<Image>();
        powerupBar = GameObject.Find("PowerUps").GetComponent<Image>();
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
      

        movementSM = new StateMachine();
        movement = new StandingState(this, movementSM);
        dashing = new DashState(this, movementSM);
        heavyAttacking = new HeavyAttackState(this, movementSM);
        lightAttacking = new LightAttackState(this, movementSM);
        specialAttacking = new SpecialAttackState(this, movementSM);
        deadState = new DeadState(this, movementSM);

        movementSM.Initialize(movement);

        menuGamePlay = GetComponent<MenuGamePlay>();

        menuGamePlay = FindObjectOfType<MenuGamePlay>();
        isAlive = true;
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

    protected void ActivateDamageImages(int cantidad)
    {

        fadeTimer = 0f;
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
            fadeTimer = fadeDuration;
        }

    }


    public void TakeDamage(float damageAmount)
    {
        life -= damageAmount;
        animator.SetTrigger("damage");
        ActivateDamageImages(Mathf.CeilToInt(life));
        LifeBarManagement();
        if (life <= 0)
        {
            Die();
            if (menuGamePlay != null)
            {
                StartCoroutine(menuGamePlay.GameOver());            
            }
        }
       
    }

    public void LifeBarManagement()
    {
        lifeBar.fillAmount = life / maxLife;       
    }

    public void PowerupManagement() 
    {
        powerupBar.fillAmount = specialCharges/3;        
    }

    void Die()
    {
        isAlive = false;  
    }
 
    protected void Update()
    {
        movementSM.currentState.HandleInput(); 
        movementSM.currentState.LogicUpdate();
        UpdateDamageImagesAlpha();
    }

    private void UpdateDamageImagesAlpha()
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
        fadeTimer -= Time.deltaTime;

        if (fadeTimer <= 0f)
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Life"))
        {
            life += 70;
            LifeBarManagement();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Power"))
        {
            specialCharges += 1;
            PowerupManagement();
            other.gameObject.SetActive(false);
        }
    }

    private void soundLightAttack()
    {
        audioSource.clip = lightAttackSound;
        audioSource.Play();
    }

    private void soundHardAttack()
    {
        audioSource.clip = hardAttackSound;
        audioSource.Play();
    }

    private void soundUlti()
    {
        audioSource.clip = ultiSound;
        audioSource.Play();
    }

}
