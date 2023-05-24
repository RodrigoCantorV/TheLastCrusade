using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsPanel : MonoBehaviour
{
    public GameObject[] panelsInstructions;

    public PlayerInput playerInput;
    public CharacterBase CharacterBase;

    public int indexPanels = 0;
    
    public InstructionsPanel(CharacterBase _character) {
        CharacterBase = _character;
    }

    /* void Start() {
        playerInput = characterBase.GetComponent<PlayerInput>();
        //panelsInstructions = GetComponent<GameObject>();
    } */

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
       

        /* for(int indexPanels = 0; indexPanels < panelsInstructions.Length; indexPanels++){
            panelsInstructions[indexPanels].SetActive(true);
            if (indexPanels == 0 && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                panelsInstructions[0].SetActive(false);
            } else if (indexPanels == 1 && Input.GetMouseButtonDown(0)) {
                panelsInstructions[1].SetActive(false);
            } else if (indexPanels == 2 && Input.GetMouseButtonDown(1)) {
                panelsInstructions[2].SetActive(false);
            }
        } */
    }
}
