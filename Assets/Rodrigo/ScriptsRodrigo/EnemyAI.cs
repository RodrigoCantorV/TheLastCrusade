using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float health = 3;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;

    [Header("Combat")]
    public float attackCD = 0.1f; // Tiempo entre los ataques
    public float attackRange = 2f; // Rango de ataque
    public float aggroRange = 4f; // Rango de movimiento para seguir al jugador

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timePassed;
    float newDestinationCD = 1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        /*
            if (player == null)
            {
                return;
            }
        */
        MoveEnemy();
        AttackEnemy();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        if (health <= 0)
        {
            Die();
        }
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

    void AttackEnemy()
    {
        if (timePassed >= attackCD)
        {
            // Si la sitancia entre el enemigo y el player es menor al rango de ataque entonces que ataque
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
                 Invoke("lanzarPoder", .8f);
            }


        }
        timePassed += Time.deltaTime;
    }

    void lanzarPoder()
    {
        if (this.gameObject.name.Equals("wizard_weapon_macanim DEMO") || this.gameObject.name.Equals("wizard_weapon_macanim DEMO (1)"))
        {
            GameObject power = PowerPool.Instance.RequestPower();
            //Vector3 position = new Vector3(transform.localPosition.x - 3, transform.position.y + 3, transform.position.z);
            //power.transform.position = gameObject.transform.position;
            Vector3 position = transform.position;
            position = position + transform.forward * 5;
            position.y += 5f;

            power.transform.position = position;
            power.transform.localEulerAngles = transform.forward;
        }

    }

    void Die()
    {
        Destroy(this.gameObject);
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


}
