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
        yield return new WaitForSeconds(0.1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameMainScene");
        //operation.allowSceneActivation = false;

        
        //loadingScreen.gameObject.SetActive(true);
        //startGame = GameObject.Find("Play")

        while (!operation.isDone) {
            Debug.Log(operation.progress + "debug operations");
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress; 
            progressText.text = (progress * 100f).ToString("F0") + "%";
             if (progress >= 0.9f)
                {
                    operation.allowSceneActivation = true; // Activa la escena cuando el progreso alcance el 90%
                }
            Debug.Log(progress + "aca el progreso");
            yield return null;
        }
    }
}
