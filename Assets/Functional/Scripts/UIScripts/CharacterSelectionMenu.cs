using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterSelectionMenu : MonoBehaviour
{

    public GameObject[] playerObjects;
    public int selectedCharacter = 0;

    public string gameScene = "Character Selection Scene";

    private string selectedCharacterDataName = "SelectedCharacter";

    public Button selectButton;
    public Button incomingButton;

    void Start()
    {

        HideAllCharacters();

        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);

        Debug.Log(selectedCharacter);
        playerObjects[selectedCharacter].SetActive(true);
    }

    private void Update()
    {
        Debug.Log(playerObjects[selectedCharacter].name);
        if (playerObjects[selectedCharacter].name == "Paladin")
        {
            selectButton.gameObject.SetActive(false);
            incomingButton.gameObject.SetActive(true);

        }
        else
        {
            selectButton.gameObject.SetActive(true);
            incomingButton.gameObject.SetActive(false);
        }
    }


    private void HideAllCharacters()
    {
        foreach (GameObject g in playerObjects)
        {
            g.SetActive(false);
        }
    }

    public void NextCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter >= playerObjects.Length)
        {
            selectedCharacter = 0;
        }
        playerObjects[selectedCharacter].SetActive(true);       
    }

    public void PreviousCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = playerObjects.Length - 1;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        
        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
        SceneManager.LoadScene(gameScene);
    }

}