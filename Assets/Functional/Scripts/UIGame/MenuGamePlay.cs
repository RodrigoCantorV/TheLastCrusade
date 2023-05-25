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
    private AudioSource audioSource;
    //public AudioClip chainGameOver;

    private void Awake()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
                audioSource.UnPause();
            }
            else
            {
                Pause();
                audioSource.Pause();
            }
        }
    }

    public void Pause()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        audioSource.Pause();
        pausePanel.SetActive(true);
        backgroundLife.SetActive(false);
        backgroundPowerup.SetActive(false);
        
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        audioSource.UnPause();
        pausePanel.SetActive(false);
        backgroundLife.SetActive(true);
        backgroundPowerup.SetActive(true);
        
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioSource.Play();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void ReturnSelectCharacter()
    {

        SceneManager.LoadScene("MenuInicial");

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
        audioSource.Pause();
    }

    public IEnumerator Winner()
    {
        yield return new WaitForSeconds(8);
        winnerPanel.SetActive(true);
        backgroundLife.SetActive(false);
        backgroundPowerup.SetActive(false);
        //Time.timeScale = 0f;
        audioSource.Pause();
    }
}