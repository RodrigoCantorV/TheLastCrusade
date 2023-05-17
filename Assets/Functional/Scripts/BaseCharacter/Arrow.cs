using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float bulletSpeed = 0.7f;

    bool isShot = false;
    Vector3 arrowDirection;
    public Transform arrowReference;
    Ray ray;
    private Rigidbody rb;
    float arrowDamage = 5;

    Vector3 realArrowDirection;

    [SerializeField]LayerMask hightFixLayer;
    void Start()
    {
        arrowReference = GameObject.Find("ArrowReference").transform; 
        rb = GetComponent<Rigidbody>();
        
    }
 

    void SetPointOfShoot()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit rayInfo, float.MaxValue, hightFixLayer))
        {
            arrowDirection = new Vector3(rayInfo.point.x, 0, rayInfo.point.z);
            realArrowDirection = arrowDirection - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShot)
        {
            transform.rotation = arrowReference.rotation;
            SetPointOfShoot();
        }
        if (isShot)
        {            
            rb.AddForce(realArrowDirection.normalized * bulletSpeed, ForceMode.Impulse );     
        }  
    }

    public void ShotArrow()
    {        
        isShot = true;
        arrowDamage = 5;
    }  
    public void ShotChargedArrow()
    {        
        isShot = true;
        arrowDamage = 10;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBoss1")|| other.CompareTag("EnemyBase1") || other.CompareTag("EnemyBase2"))
        {
            gameObject.SetActive(false);
            print("Flechado");
        }
        //gameObject.SetActive(false);
    }

}
