using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPower : MonoBehaviour
{

    Vector3 playerPosition;
    Vector3 directionFinal;

    Vector3 posicionJugadorActual;

    GameObject floor;

    public Transform target; // El objeto hacia el que se moverá el objeto actual
    public float speed = 5; // La velocidad a la que se moverá el objeto actua

    private void OnEnable()
    {
        floor = GameObject.Find("Floor");
        target = GameObject.Find("Player").transform;
        posicionJugadorActual = target.position;
        // posicionJugadorActual.y -= 2;
        //posicionJugadorActual.x -= 3;
        //posicionJugadorActual.z += 2;
    }

    private void Update()
    {
        directionFinal = (posicionJugadorActual - transform.position).normalized; // Calcular la dirección hacia el objeto objetivo
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = (directionFinal * 2 * speed); // Mover el objeto en la dirección calculada a la velocidad especificada
        if (Vector3.Distance(transform.position, posicionJugadorActual) < 0.5f)
        {

            //Debug.Log("El objeto ha llegado a la posición del jugador");
            Invoke("Desactivar", .1f);

            GameObject po = GetComponentInParent<PowerPool>().gameObject;
            GameObject ppo = po.GetComponentInParent<EnemyLongDistance>().gameObject;
            ppo.GetComponentInParent<EnemyLongDistance>().EndDealDamage();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("Golpeo al jugador con la bola del poder");

            GameObject po = GetComponentInParent<PowerPool>().gameObject;
            GameObject ppo = po.GetComponentInParent<EnemyLongDistance>().gameObject;
            ppo.GetComponentInParent<EnemyLongDistance>().EndDealDamage();
            this.gameObject.SetActive(false);
            // Debug.Log(ppo.name);
        }
    }


    void Desactivar()
    {

        this.gameObject.SetActive(false);

    }

}
