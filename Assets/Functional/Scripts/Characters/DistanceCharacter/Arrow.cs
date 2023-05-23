using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float bulletSpeed = 20f;
    bool isShot = false;
    Vector3 arrowDirection;
    private Transform arrowReference;
    Ray ray;
    private Rigidbody rb;
    float arrowDamage = 5;
    Vector3 offsetSpecialAttack = new Vector3(1, 0, 1);
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
    }

    public void ShotArrow()
    {
        arrowDamage = 50;
        Shot();
    }  
    public void ShotChargedArrow()
    {
        arrowDamage = 130;
        print("disparando");
        Shot();
    }

    public void ShotSpecialAttack(int arrowCounter)
    {
        arrowDamage = 100;
        ShotSpecial(arrowCounter);   
    }

    void Shot()
    {
        transform.rotation = arrowReference.rotation;
              
        rb.AddForce(realArrowDirection.normalized * bulletSpeed, ForceMode.Impulse);

        print("disparandisimo");
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

            gameObject.SetActive(false);
            print("arrow Damage: " + arrowDamage);
        }
        if (other.CompareTag("Enviroment")){
            gameObject.SetActive(false);
        }
        
    }



}
