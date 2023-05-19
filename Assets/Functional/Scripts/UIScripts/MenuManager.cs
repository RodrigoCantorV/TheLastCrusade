using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuInit;
    [SerializeField] private GameObject menuSelect;
    public void StartButton()
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
