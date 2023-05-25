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

        Debug.Log("revise y active los paneles");  

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

    /* IEnumerator CheckInputForPanel()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        panelsInstructions[indexPanels].SetActive(true); */

        /* //int timeDelay = (int)Time.time;
        //yield return new WaitForSeconds(2f);
        //int timeDelay = (int)Time.time;

        //playerInput = characterBase.GetComponent<PlayerInput>();
        if (indexPanels == 0 && timeDelay % 3 == 0 && playerInput.FindAction("Move").IsPressed())
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            Debug.Log(panelsInstructions);
            //StartCoroutine(ShowPanelsWithDelay());
            indexPanels++;
            Debug.Log(indexPanels);
        }

        yield return new WaitForSeconds(2f);
        NextPanel(indexPanels);

        if (indexPanels == 1 && timeDelay % 3 == 0 && playerInput.FindAction("LightAttack").IsPressed())
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            //StartCoroutine(ShowPanelsWithDelay());
            //ShowPanelsWithDelay();
            indexPanels++;
            Debug.Log(indexPanels);
        }

        yield return new WaitForSeconds(2f);
        NextPanel(indexPanels);
        
        if (indexPanels == 2 && timeDelay % 3 == 0 && playerInput.FindAction("HeavyAttack").IsPressed())
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            //NextPanel();
            //StartCoroutine(ShowPanelsWithDelay());
            //ShowPanelsWithDelay();
            indexPanels++;
            Debug.Log(indexPanels);
        }
        yield return new WaitForSeconds(2f);
        NextPanel(indexPanels);
        if (indexPanels == 3 && timeDelay % 3 == 0 && playerInput.FindAction("Dash").IsPressed())
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            //NextPanel();
            //StartCoroutine(ShowPanelsWithDelay());
            //ShowPanelsWithDelay();
            indexPanels++;
            Debug.Log(indexPanels);
        }
        yield return new WaitForSeconds(2f);
        NextPanel(indexPanels);
        if (indexPanels == 4 && timeDelay % 3 == 0 && playerInput.FindAction("SpecialAttack").IsPressed())
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            //NextPanel();
            //StartCoroutine(ShowPanelsWithDelay());
            //ShowPanelsWithDelay();
            indexPanels++;
            Debug.Log(indexPanels);
        }
        yield return new WaitForSeconds(2f);
        NextPanel(indexPanels);
        if (indexPanels == 5 && timeDelay % 3 == 0 && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            panelsInstructions[indexPanels].SetActive(false);
            //Invoke("NextPanel", 2f);
            //NextPanel();
            //StartCoroutine(ShowPanelsWithDelay());
            //ShowPanelsWithDelay();
            indexPanels++;
            Debug.Log(indexPanels);
        } */
        
    //}

    

    /* void NextPanel(int indexPanels)
    {
        if (indexPanels < panelsInstructions.Length)
        {
            panelsInstructions[indexPanels].SetActive(true);
        }
    } */

    /* IEnumerator ShowPanelsWithDelay()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        panelsInstructions[indexPanels].SetActive(true);
        //yield return new WaitForSeconds(3f);
    } */
    

   /*  public InstructionsPanel(CharacterBase _character) {
        CharacterBase = _character;
    }

    void Start() {
        playerInput = characterBase.GetComponent<PlayerInput>();
        //panelsInstructions = GetComponent<GameObject>();
    }

    void Update() {
        ActivePanels();
    }
    
    void ActivePanels() {
        //int panelSecuence = panelsInstructions.Length;
        //int indexPanels = 0;

        panelsInstructions[indexPanels].SetActive(true);

        if (indexPanels == 0 && CharacterBase.playerInput.actions["Move"].IsPressed()) {
            panelsInstructions[0].SetActive(false);
        } else if (indexPanels == 1 && CharacterBase.playerInput.actions["LightAttack"].IsPressed()) {
            panelsInstructions[1].SetActive(false);
        } else if (indexPanels == 2 && CharacterBase.playerInput.actions["HeavyAttack"].IsPressed()) {
            panelsInstructions[2].SetActive(false);
        } else if (indexPanels == 3 && CharacterBase.playerInput.actions["Dash"].IsPressed()) {
            panelsInstructions[3].SetActive(false);
        } else if (indexPanels == 4 && CharacterBase.playerInput.actions["SpecialAttack"].IsPressed()) {
            panelsInstructions[4].SetActive(false);
        } else if (indexPanels == 5 && Input.GetKeyDown(KeyCode.Escape)) {
            panelsInstructions[5].SetActive(false);
        }
       

        for(int indexPanels = 0; indexPanels < panelsInstructions.Length; indexPanels++){
            panelsInstructions[indexPanels].SetActive(true);
            if (indexPanels == 0 && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                panelsInstructions[0].SetActive(false);
            } else if (indexPanels == 1 && Input.GetMouseButtonDown(0)) {
                panelsInstructions[1].SetActive(false);
            } else if (indexPanels == 2 && Input.GetMouseButtonDown(1)) {
                panelsInstructions[2].SetActive(false);
            }
        }
    } */
}
