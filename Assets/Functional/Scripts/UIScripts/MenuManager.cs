using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject returnBack;
    [SerializeField] private GameObject tagg;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject logo;

    [SerializeField] private GameObject next;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject previous;

    //[SerializeField] private GameObject playerSelect;

    // Start is called before the first frame update
    public void StartButton()
    {
        background.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        tagg.SetActive(false);
        enemy.SetActive(false);
        player.SetActive(false);
        logo.SetActive(false);
        //playerSelect.SetActive(true);
        next.SetActive(true);
        previous.SetActive(true);
        play.SetActive(true);
        returnBack.SetActive(true);
    }

    public void ReturnBack()
    {
        background.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
        tagg.SetActive(true);
        enemy.SetActive(true);
        player.SetActive(true);
        logo.SetActive(true);
        //playerSelect.SetActive(false);
        next.SetActive(false);
        previous.SetActive(false);
        play.SetActive(false);
        returnBack.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Cierra la app");
        Application.Quit();
    }

    //public void SettingsButton()
    //{
    //    startButton.SetActive(false);
    //    settingsButton.SetActive(false);
    //}

    //public void PlayerSelect()
    //{
    //    playerSelect.SetActive(false);
    //    playerSelect.SetActive(true);
    //}
}
