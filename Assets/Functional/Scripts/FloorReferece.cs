using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorReferece : MonoBehaviour
{

    Vector3 posicionMouse;
    public GameObject positionReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del mouse
        {
            // Obt�n la posici�n del clic en la pantalla
            posicionMouse = Input.mousePosition;

            // Convierte la posici�n del clic de pantalla a un rayo en el mundo
            Ray rayo = Camera.main.ScreenPointToRay(posicionMouse);

            // Realiza un lanzamiento de rayo desde la c�mara hacia el clic del mouse
            RaycastHit hit;
            if (Physics.Raycast(rayo, out hit))
            {
                // Verifica si el rayo colision� con un objeto
                if (hit.collider.gameObject == gameObject)
                {
                    // Mueve el objeto hacia la posici�n del clic del mouse
                    positionReference.transform.position = hit.point;
                    positionReference.transform.position = new Vector3(positionReference.transform.position.x, positionReference.transform.position.y + 1, positionReference.transform.position.z);
                    //Debug.Log(algo.transform.position);
                }
            }
        }
    }
}

