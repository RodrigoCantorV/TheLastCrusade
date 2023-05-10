using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target; // Este es el objeto que seguirá la cámara
    //public float distance = 10f; // Esta es la distancia fija entre la cámara y el objetivo
    //
    //private void LateUpdate()
    //{
    //// Obtiene la posición global del personaje
    //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -distance));
    //
    //// Desplaza la posición de la cámara hacia la posición global del personaje
    //transform.position = targetPosition;
    //
    //// Asegura que la cámara siempre mire hacia el personaje
    //transform.LookAt(target);

    //}

    public Transform target; // Este es el objeto que seguirá la cámara
    public float distance = 10f; // Esta es la distancia fija entre la cámara y el objetivo
    public float height = 3f; // Esta es la altura fija de la cámara sobre el objetivo
    public float smoothTime = 0.3f; // Este es el tiempo que tardará la cámara en moverse hacia el objetivo
    public float shakeIntensity = 0.05f; // Intensidad de la vibración de la cámara

    private Vector3 velocity = Vector3.zero;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition; // Almacena la posición original de la cámara
    }

    private void LateUpdate()
    {
        // Obtiene la posición global del personaje
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, height, -distance));

        // Desplaza la posición de la cámara hacia la posición global del personaje
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Crea una vibración aleatoria de la cámara
        Vector3 shake = Random.insideUnitSphere * shakeIntensity;
        shake.z = 0f;

        // Aplica la vibración a la posición de la cámara
        transform.localPosition = originalPosition + shake;

        // Asegura que la cámara siempre mire hacia el personaje
        transform.LookAt(target);
    }
}
