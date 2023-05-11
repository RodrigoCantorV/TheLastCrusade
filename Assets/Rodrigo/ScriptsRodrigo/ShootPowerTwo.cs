using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerTwo : MonoBehaviour
{
    Rigidbody rb;
    Vector3 targetPosition;
    Vector3 directionFinal;
    float force = 5f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        targetPosition = GameObject.Find("Player").transform.position;
        directionFinal = (targetPosition - this.transform.position).normalized;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(directionFinal * force, ForceMode.Impulse);
        //rb.velocity = directionFinal * force;
        // rb.AddForce(transform.forward * force, ForceMode.Impulse)
    }

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
