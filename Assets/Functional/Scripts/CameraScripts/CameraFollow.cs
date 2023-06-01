using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objeto a seguir 
    public float distance = 10f; // Distancia entre la c�mara y el objeto a seguir
    public float smoothSpeed = 0.5f; // Velocidad de movimiento de la c�mara
    public float yRotation = 0.0f; // Rotaci�n en el eje Y
    public float yRotationAux = 40f; // Rotaci�n en el eje Y
    public float yRotationRerence;
    public float XRotation = 0.0f; // Rotaci�n en el eje Y
    private Vector3 velocity = Vector3.zero;
    private bool camInWall = false;
    private CharacterBase characterBase;
    private float distanceRef;
    private float transitionSmoothTime=1; 

    private Vector3 newPosition;
    void LateUpdate()
    {
        characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Posici�n actual de la c�mara - maincamera
        Vector3 currentPosition = transform.position;

        // Posici�n a la que debe moverse la c�mara
        Vector3 targetPosition = target.position - transform.forward * distance;

        //// Creamos una rotaci�n en el eje Y
        Quaternion yRotationQuaternion = Quaternion.Euler(yRotation, XRotation, 0);

        float camVPlayerDistance = Vector3.Distance(transform.position, target.position);
       // print(camVPlayerDistance);

        //// Actualizamos la rotaci�n de la c�mara
        transform.rotation = yRotationQuaternion;


        if (!camInWall)
        {
            distance = Mathf.SmoothDamp(distance, 13, ref distanceRef, transitionSmoothTime);
            //distance = 13;
            yRotation = Mathf.SmoothDamp(yRotation, 45, ref distanceRef, transitionSmoothTime);
            //yRotation = 45;

        }    
        else
        {
            distance = Mathf.SmoothDamp(distance, 16, ref distanceRef, transitionSmoothTime);
            yRotation = Mathf.SmoothDamp(yRotation, 60, ref distanceRef, transitionSmoothTime);
           // distance = 16;
           // yRotation = 60;
            //Vector3 targetDirection = target.position - transform.position;
           // transform.rotation = Quaternion.LookRotation(targetDirection);
           // transform.position = transform.position;
            camInWall = false;
        };
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);


        if (!characterBase.isAlive) {
             // Calculamos la nueva posición de la cámara
            targetPosition = target.position - transform.forward * 5f;
            
            // Movimiento suave de la cámara hacia la nueva posición
            newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.2f);
            transform.position = newPosition;        
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("colision");
        camInWall = true;
    }
    private void OnTriggerStay(Collider other)
    {
        print("colision2");
        camInWall =true;
    }

}
