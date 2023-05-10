using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objeto a seguir
    public float distance = 10f; // Distancia entre la c�mara y el objeto a seguir
    public float smoothSpeed = 0.5f; // Velocidad de movimiento de la c�mara

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Posici�n actual de la c�mara
        Vector3 currentPosition = transform.position;

        // Posici�n a la que debe moverse la c�mara
        Vector3 targetPosition = target.position - transform.forward * distance;

        // Movimiento suave de la c�mara
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);
    }

}
