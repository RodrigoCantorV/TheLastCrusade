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
        //float max = Vector3.Distance(this.transform.position, target.position);
        // Vector3 distanceVector = this.transform.position - target.position;
        //float distance2 = distanceVector.magnitude;

        //Debug.Log("===========" + max);
/*
        if (characterBase.estaAfuera == false)
        {
            max = Vector3.Distance(this.transform.position, target.position);
        }
        else
        {
            max = 0;
        }

        if (max > 11)
        {
            estaTocando = false;
        }


        if (estaTocando == true)
        {
            yRotationAux = 50;
            yRotation = Mathf.SmoothDamp(yRotation, yRotationAux, ref yRotationRerence, 0.1f);
        }
        if (estaTocando == false)
        {
            yRotationAux = 40;
            yRotation = Mathf.SmoothDamp(yRotation, yRotationAux, ref yRotationRerence, 0.1f);
        }
*/
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Toco la pared triger enter");
        estaTocando = false;
    }


    private void OnTriggerExit(Collider other)
    {
        estaTocando = true;
        Debug.Log("Toco la pared triger exit");
        //yRotationAux = 60;
        // estaTocando = true;    // donde estamos  // donde quiero llegar // no se toca// velocidad con la que va a cambiar
        // yRotation = Mathf.SmoothDamp(yRotation, yRotationAux, ref yRotationRerence, 4.0f);
    }



    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Toco la pared triger stay");
        estaTocando = false;
    }
*/
}
