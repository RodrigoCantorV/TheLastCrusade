using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target; // Este es el objeto que seguir� la c�mara
    //public float distance = 10f; // Esta es la distancia fija entre la c�mara y el objetivo
    //
    //private void LateUpdate()
    //{
    //// Obtiene la posici�n global del personaje
    //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -distance));
    //
    //// Desplaza la posici�n de la c�mara hacia la posici�n global del personaje
    //transform.position = targetPosition;
    //
    //// Asegura que la c�mara siempre mire hacia el personaje
    //transform.LookAt(target);

    //}

    public Transform target; // Este es el objeto que seguir� la c�mara
    public float distance = 10f; // Esta es la distancia fija entre la c�mara y el objetivo
    public float height = 3f; // Esta es la altura fija de la c�mara sobre el objetivo
    public float smoothTime = 0.3f; // Este es el tiempo que tardar� la c�mara en moverse hacia el objetivo
    public float shakeIntensity = 0.05f; // Intensidad de la vibraci�n de la c�mara

    private Vector3 velocity = Vector3.zero;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition; // Almacena la posici�n original de la c�mara
    }

    private void LateUpdate()
    {
        // Obtiene la posici�n global del personaje
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, height, -distance));

        // Desplaza la posici�n de la c�mara hacia la posici�n global del personaje
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Crea una vibraci�n aleatoria de la c�mara
        Vector3 shake = Random.insideUnitSphere * shakeIntensity;
        shake.z = 0f;

        // Aplica la vibraci�n a la posici�n de la c�mara
        transform.localPosition = originalPosition + shake;

        // Asegura que la c�mara siempre mire hacia el personaje
        transform.LookAt(target);
    }
}
