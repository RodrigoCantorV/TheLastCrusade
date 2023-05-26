using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingBar : MonoBehaviour
{
    public GameObject loadingScreen;
    //public CharacterSelectionMenu startGame;
    public TextMeshProUGUI progressText;
    public Slider slider;

    public void LoadLevel(string nameScene) {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronusly(nameScene));
    }

    IEnumerator LoadAsynchronusly(string nameScene) {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameMainScene");
        
        //loadingScreen.SetActive(true);
        //startGame = GameObject.Find("Play")

        while (!operation.isDone) {
            Debug.Log(operation.progress + "debug operations");
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress; 
            progressText.text = progress * 100f + "%";
            Debug.Log(progress + "aca el progreso");
            yield return null;
        }
    }
}
