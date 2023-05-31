using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SelectChar");
    }

    /* public void MenuSelectCharacter()
    {
        SceneManager.LoadScene("SelectChar");
    } */
    
    public void Credits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ReturnBack()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void Exit()
    {
        Debug.Log("Cierra la app");
        Application.Quit();
    }
}
