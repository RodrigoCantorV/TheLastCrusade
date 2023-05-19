using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Live")]
    // Variable de vida para todos los enemigos
    [SerializeField] float health = 3;
    // Variable para el efecto visual cusndo el enemigo sea golpeado
    [SerializeField] GameObject hitVFX;

    [Header("Combat")]
    // Tiempo entre los ataques
    public float attackTime = 0.1f;
    // Rango de ataque
    public float attackRange;
    // Rango de movimiento para seguir al jugador
    public float aggroRange;

    protected GameObject player;
    NavMeshAgent agent;
    protected Animator animator;
    protected float timePassed;
    protected float newDestinationCD = 1f;

    void Start()
    {

    }


    void Update()
    {

    }

    private void LateUpdate()
    {
        InitializeVariables();
        MoveEnemy();
        AttackEnemy();
        //Obser();
    }

    void InitializeVariables()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    void MoveEnemy()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange && animator.GetBool("isAttack") == false)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        HitVFX(this.gameObject.transform.position);
        if (health <= 0)
        {
            GameManager.can--;
            if (GameManager.can == 0)
            {
                GameManager.esCero = true;
            }
            Debug.Log(GameManager.can);
            Die();

        }
    }


    void Die()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
        animator.SetBool("isAttack", true);
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
        animator.SetBool("isAttack", false);
    }

    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    void Obser()
    {
        transform.LookAt(player.transform.position);
    }

    protected abstract void AttackEnemy();
}
