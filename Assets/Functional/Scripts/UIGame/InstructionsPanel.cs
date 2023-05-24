using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsPanel : MonoBehaviour
{
    public GameObject[] panelsInstructions;

    [HideInInspector] public PlayerInput playerInput;
    [HideInInspector] public CharacterBase characterBase;

    [HideInInspector] public int indexPanels = 0;

    private bool gameStarted = false;

    void Start()
    {
        playerInput = characterBase.GetComponent<PlayerInput>();
        StartCoroutine(ShowPanelsWithDelay());
    }

    void Update()
    {
        if (!gameStarted)
            return;

        if (panelsInstructions[indexPanels].activeSelf)
        {
            CheckInputForPanel();
        }
    }

    void CheckInputForPanel()
    {
        if (indexPanels == 0 && playerInput.actions["Move"].IsPressed())
        {
            panelsInstructions[0].SetActive(false);
            NextPanel();
        }
        else if (indexPanels == 1 && playerInput.actions["LightAttack"].IsPressed())
        {
            panelsInstructions[1].SetActive(false);
            NextPanel();
        }
        else if (indexPanels == 2 && playerInput.actions["HeavyAttack"].IsPressed())
        {
            panelsInstructions[2].SetActive(false);
            NextPanel();
        }
        else if (indexPanels == 3 && playerInput.actions["Dash"].IsPressed())
        {
            panelsInstructions[3].SetActive(false);
            NextPanel();
        }
        else if (indexPanels == 4 && playerInput.actions["SpecialAttack"].IsPressed())
        {
            panelsInstructions[4].SetActive(false);
            NextPanel();
        }
        else if (indexPanels == 5 && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            panelsInstructions[5].SetActive(false);
            NextPanel();
        }
    }

    void NextPanel()
    {
        indexPanels++;
        if (indexPanels < panelsInstructions.Length)
        {
            panelsInstructions[indexPanels].SetActive(true);
        }
        else
        {
            // Se han mostrado todos los paneles, aquí puedes realizar alguna acción adicional si es necesario.
        }
    }

    IEnumerator ShowPanelsWithDelay()
    {
        yield return new WaitForSeconds(3f);
        gameStarted = true;
        panelsInstructions[indexPanels].SetActive(true);
    }
    
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
