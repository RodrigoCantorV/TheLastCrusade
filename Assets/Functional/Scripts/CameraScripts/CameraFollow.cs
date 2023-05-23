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
    private bool estaTocando = false;
    private float sumatoria;
    private CharacterBase characterBase;

    private Vector3 newPosition;
    float max;
    private void Start()
    {
        // characterBase = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBase>();
    }
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

        //// Actualizamos la rotaci�n de la c�mara
        transform.rotation = yRotationQuaternion;

        if (estaTocando == false)
        {
            // Movimiento suave de la c�mara
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);
        }

        if (!characterBase.estaVivo) {
             // Calculamos la nueva posición de la cámara
            targetPosition = target.position - transform.forward * 5f;
            
            // Movimiento suave de la cámara hacia la nueva posición
            newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.2f);
            transform.position = newPosition;
            Debug.Log("Muerteeee");
        }
        
    }
}
