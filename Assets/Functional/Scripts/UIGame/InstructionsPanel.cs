using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsPanel : MonoBehaviour
{
    public GameObject[] panelsInstructions;

    public InputActionAsset playerInput;
    [HideInInspector] public CharacterBase characterBase;

    [HideInInspector] public int indexPanels = 0;

    private bool gameStarted = false;

    int time;
    bool estaActivo = true;
    int cantidadPanel = 0;
    int contadorPasos = 1;
    public GameManager cinematicManagement;

    //private bool gameStarted = false;
    //private int activatedPanels = 0;
    
    void Start()
    {
        time = (int)Time.time;
        //StartCoroutine(ShowPanelsWithDelay());
        //StartCoroutine(CheckInputForPanel());
        //StartCoroutine(ContadorTiempo());
    }

    void Update()
    {
        int elapsedTime = (int)Time.time - time;
        Debug.Log(elapsedTime);
        if(elapsedTime > 1 && elapsedTime == 5 && estaActivo == true) {
            estaActivo = false;
            switch (cantidadPanel)
            {
                case 0:
                    //StartCoroutine(ContadorTiempo());
                    panelsInstructions[0].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 1:
                    panelsInstructions[1].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 2:
                    panelsInstructions[2].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 3:
                    panelsInstructions[3].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 4:
                    panelsInstructions[4].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 5:
                    panelsInstructions[5].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                case 6:
                    panelsInstructions[6].gameObject.SetActive(true);
                    Debug.Log("Activo panel" + cantidadPanel);
                    break;
                //default:
            }
        }  

        if (contadorPasos == 1 && playerInput.FindAction("Move").IsPressed() && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            contadorPasos++;
            ResetTimer();
            estaActivo = true;
            cantidadPanel++;
        }
        if (contadorPasos == 2 && playerInput.FindAction("LightAttack").IsPressed() && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            contadorPasos++;
            ResetTimer();
            estaActivo = true;
            cantidadPanel++;
        }
        if (contadorPasos == 3 && playerInput.FindAction("HeavyAttack").IsPressed() && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            contadorPasos++;
            ResetTimer();
            estaActivo = true;
            cantidadPanel++;
        }
        if (contadorPasos == 4 && playerInput.FindAction("Dash").IsPressed() && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            contadorPasos++;
            ResetTimer();
            estaActivo = true;
            cantidadPanel++;
        }
        if (contadorPasos == 5 && playerInput.FindAction("SpecialAttack").IsPressed() && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            contadorPasos++;
            ResetTimer();
            estaActivo = true;
            cantidadPanel++;
        }
        if (contadorPasos == 6 && Input.GetKeyDown(KeyCode.Escape) && elapsedTime > 7)
        {
            panelsInstructions[cantidadPanel].gameObject.SetActive(false);
            //contadorPasos++;
            //ResetTimer();
            //estaActivo = true;
            //cantidadPanel++;
        }
    }

    public void ResetTimer() {
        time = (int)Time.time;
    }
}
