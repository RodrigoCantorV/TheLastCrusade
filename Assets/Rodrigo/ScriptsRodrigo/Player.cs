using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public EnemyAI enemy;
    // Start is called before the first frame update
    void Start()
    {
       enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
           enemy.TakeDamage(1);
           Vector3 posFinal = other.transform.position;
           posFinal.y = 3f;
           enemy.HitVFX(posFinal);
        }
    }

    private void OnTriggerEnter(Collider other) {
       // Debug.Log("El poder colisiono con el jugador");
    }
}
