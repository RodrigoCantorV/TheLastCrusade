using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float bulletSpeed = 10;
    private Transform frontFocalPoint;
    Vector3 bulletDirection;
    void Start()
    {
        frontFocalPoint = GameObject.Find("FocalPoint").transform;
        bulletDirection = frontFocalPoint.forward;
        //Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime, Space.World);
    }
}
