using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private Transform arrowReference;
    bool isShot = false;   
    float bulletSpeed = 20f;
    float arrowDamage = 5;
    Vector3 offsetSpecialAttack = new Vector3(1, 0, 1);
    Vector3 arrowDirection;
    Vector3 realArrowDirection;
    Ray ray;
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
    void Update()
    {        
        if (!isShot)
        {
            transform.rotation = arrowReference.rotation;
            SetPointOfShoot();
        } 
    }

    public void ShotArrow()
    {
       
        arrowDamage = 35;
        SetPointOfShoot();
        Shot();
    }  
    public void ShotChargedArrow()
    {
        arrowDamage = 60;
        SetPointOfShoot();
        Shot();
    }

    public void ShotSpecialAttack(int arrowCounter)
    {
        arrowDamage = 80;
        SetPointOfShoot();
        ShotSpecial(arrowCounter);   
    }

    void Shot()
    {
        transform.rotation = arrowReference.rotation;              
        rb.AddForce(realArrowDirection.normalized * bulletSpeed, ForceMode.Impulse);
        isShot = true;
    }

    void ShotSpecial(int arrowCounter) {
        transform.rotation = arrowReference.rotation;
        isShot = true;       
        if (arrowCounter == 0)
        {
            realArrowDirection = realArrowDirection - offsetSpecialAttack;
        }
        if (arrowCounter == 2)
        {
            realArrowDirection = realArrowDirection + offsetSpecialAttack;
        }
        rb.AddForce(realArrowDirection.normalized * bulletSpeed, ForceMode.Impulse);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBoss1")|| other.CompareTag("EnemyBase1") || other.CompareTag("EnemyBase2"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();         
            enemy.TakeDamage(arrowDamage);
            rb.velocity = Vector3.zero;            
            gameObject.SetActive(false);
            
        }
        if (other.CompareTag("Enviroment")){
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enviroment"))
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

    }

    private void OnDisable()
    {
        transform.position = new Vector3(0, 0, 0);
        //transform.rotation = Quaternion.Euler(0, 0, 0);       
    }



}
