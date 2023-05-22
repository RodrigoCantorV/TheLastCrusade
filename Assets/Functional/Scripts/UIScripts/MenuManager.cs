using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //[SerializeField] public GameObject menuInit;
    //[SerializeField] public GameObject menuSelect;

   /*  void Start() 
    {
        SceneManager.LoadScene("SelectChar");
        menuInit.SetActive(true);
        menuSelect.SetActive(false);
    } */

    public void StartButton()
    {
        SceneManager.LoadScene("SelectChar");
        /* menuInit.SetActive(false);
        menuSelect.SetActive(true); */
    }

    public void MenuSelectCharacter()
    {
        SceneManager.LoadScene("SelectChar");
        /* menuInit.SetActive(false);
        menuSelect.SetActive(true); */
    }

    public void ReturnBack()
    {
        SceneManager.LoadScene("MenuInicial");
        /* menuInit.SetActive(true);
        menuSelect.SetActive(false); */
    }


    public void Exit()
    {
        Debug.Log("Cierra la app");
        Application.Quit();
    }
}
