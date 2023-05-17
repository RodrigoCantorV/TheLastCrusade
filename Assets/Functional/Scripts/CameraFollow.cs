using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objeto a seguir 
    public float distance = 10f; // Distancia entre la c�mara y el objeto a seguir
    public float smoothSpeed = 0.5f; // Velocidad de movimiento de la c�mara
    public float yRotation = 0.0f; // Rotaci�n en el eje Y

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Posici�n actual de la c�mara - maincamera
        Vector3 currentPosition = transform.position;

        // Posici�n a la que debe moverse la c�mara
        Vector3 targetPosition = target.position - transform.forward * distance;

        //// Creamos una rotaci�n en el eje Y
        Quaternion yRotationQuaternion = Quaternion.Euler(yRotation, 0, 0);

        //// Actualizamos la rotaci�n de la c�mara
        transform.rotation = yRotationQuaternion;

        // Movimiento suave de la c�mara
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);
    }
}
