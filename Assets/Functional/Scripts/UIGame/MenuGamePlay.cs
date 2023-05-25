using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject backgroundLife;
    [SerializeField] private GameObject backgroundPowerup;
    [SerializeField] private GameObject gameOverLetter;
    Animator animatorLetter;
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject winnerPanel;
    [SerializeField] public MenuManager menuManager;
    //public GameObject pausePanel;

    private bool juegoPausado = false;

    private void Awake()
    {
        SoundManager.Instance.playSoundBack();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
                SoundManager.Instance.playSoundBack();
            }
            else
            {
                Pause();
                SoundManager.Instance.pauseSoundBack();
            }
        }
    }

    public void Pause()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        SoundManager.Instance.pauseSoundBack();
        botonPause.SetActive(false);
        pausePanel.SetActive(true);
        backgroundLife.SetActive(false);
        backgroundPowerup.SetActive(false);
        
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        backgroundLife.SetActive(true);
        backgroundPowerup.SetActive(true);
        //resume.SetActive(false);
        //restart.SetActive(false);
        //quit.SetActive(false);
        //volume.SetActive(false);

        SoundManager.Instance.playSoundBack();
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundManager.Instance.playSoundBack();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void ReturnSelectCharacter()
    {

        SceneManager.LoadScene("MenuInicial");

        //GameObject objeto = GameObject.Find("CanvasMenuInitNew");
        Debug.Log("cambio a selecccion");
        menuManager.MenuSelectCharacter();
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(6.5f);
        gameOverPanel.SetActive(true);
        backgroundLife.SetActive(false);
        backgroundPowerup.SetActive(false);
        animatorLetter = gameOverLetter.GetComponent<Animator>();
        animatorLetter.SetTrigger("lose");
        //Time.timeScale = 0f;
        //audioSource.Pause();
        
        SoundManager.Instance.pauseSoundBack();
        SoundManager.Instance.playSoundLose();
    }

    public IEnumerator Winner()
    {
        yield return new WaitForSeconds(8);
        winnerPanel.SetActive(true);
        backgroundLife.SetActive(false);
        backgroundPowerup.SetActive(false);
        botonPause.SetActive(false);
        Time.timeScale = 0f;
        SoundManager.Instance.pauseSoundBack();
    }
}