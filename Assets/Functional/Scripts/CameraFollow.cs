using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;
    //public float smoothTime = 0.3f;
    //public Vector3 offset;
    //public float followSpeed = 10.0f;
    //public float yRotation = 0.0f; // Rotación en el eje Y

    //private Vector3 velocity = Vector3.zero;

    //void FixedUpdate()
    //{
    //    // Obtenemos la posicion actual de la camara
    //    Vector3 desiredPosition = target.position + offset;

    //    // Hacemos un smooth con la posicion actual de la camara y la posicion deseada
    //    //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);

    //    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

    //    // Creamos una rotación en el eje Y
    //    Quaternion yRotationQuaternion = Quaternion.Euler(yRotation, 0, 0);

    //    // Actualizamos la rotación de la cámara
    //    transform.rotation = yRotationQuaternion;


    //    // Actualizamos la posicion de la camara
    //    transform.position = smoothedPosition;
    //}

    public Transform target; // Objeto a seguir
    public float distance = 10f; // Distancia entre la cámara y el objeto a seguir
    public float smoothSpeed = 0.5f; // Velocidad de movimiento de la cámara
    //public float yRotation = 0.0f; // Rotación en el eje Y

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Posición actual de la cámara
        Vector3 currentPosition = transform.position;

        // Posición a la que debe moverse la cámara
        Vector3 targetPosition = target.position - transform.forward * distance;

        //// Creamos una rotación en el eje Y
        //Quaternion yRotationQuaternion = Quaternion.Euler(yRotation, 0, 0);

        //// Actualizamos la rotación de la cámara
        //transform.rotation = yRotationQuaternion;

        // Movimiento suave de la cámara
        transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothSpeed);
    }

    //public Transform target;
    //public float smoothTime = 0.3f;
    //public Vector3 offset;

    //private Vector3 velocity = Vector3.zero;

    //void LateUpdate()
    //{
    //    // Obtenemos la posicion actual de la camara
    //    Vector3 desiredPosition = target.position + offset;

    //    // Hacemos un smooth con la posicion actual de la camara y la posicion deseada
    //    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

    //    // Actualizamos la posicion de la camara
    //    transform.position = smoothedPosition;
    //}

}
