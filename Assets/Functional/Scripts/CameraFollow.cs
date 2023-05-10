using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objeto a seguir
    public float distance = 10f; // Distancia entre la cámara y el objeto a seguir
    public float smoothSpeed = 0.5f; // Velocidad de movimiento de la cámara

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Posición actual de la cámara
        Vector3 currentPosition = transform.position;

        // Posición a la que debe moverse la cámara
        Vector3 targetPosition = target.position - transform.forward * distance;

        // Movimiento suave de la cámara
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);
    }

}
