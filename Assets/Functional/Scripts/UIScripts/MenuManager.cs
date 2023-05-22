using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject menuInit;
    [SerializeField] public GameObject menuSelect;

    void Start() 
    {
        menuInit.SetActive(true);
        menuSelect.SetActive(false);
    }

    public void StartButton()
    {
        menuInit.SetActive(false);
        menuSelect.SetActive(true);
    }

    public void MenuSelectCharacter()
    {
        menuInit.SetActive(false);
        menuSelect.SetActive(true);
    }

    public void ReturnBack()
    {
        menuInit.SetActive(true);
        menuSelect.SetActive(false);
    }


    public void Exit()
    {
        Debug.Log("Cierra la app");
        Application.Quit();
    }
}
