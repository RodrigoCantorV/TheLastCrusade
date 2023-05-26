﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public GameObject[] characters;
    public Transform playerStartPosition;
    public string menuScene = "SelectChar";
    private string selectedCharacterDataName = "SelectedCharacter";
    int selectedCharacter;
    public GameObject playerObject;
  
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName,0);
        playerObject = Instantiate(characters[selectedCharacter],playerStartPosition.position,characters[selectedCharacter].transform.rotation);
    }
}