using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGamePlay : MonoBehaviour
{
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject pausePanel;
    //[SerializeField] private GameObject quit;
    //[SerializeField] private GameObject resume;
    //[SerializeField] private GameObject restart;
    //[SerializeField] private GameObject volume;
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] public GameObject winnerPanel;
    [SerializeField] public MenuManager menuManager;
    //public GameObject pausePanel;

    private bool juegoPausado = false;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        botonPause.SetActive(false);
        pausePanel.SetActive(true);
        //resume.SetActive(true);
        //restart.SetActive(true);
        //quit.SetActive(true);
        //volume.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPause.SetActive(true);
        pausePanel.SetActive(false);
        //resume.SetActive(false);
        //restart.SetActive(false);
        //quit.SetActive(false);
        //volume.SetActive(false);

        audioSource.UnPause();
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
        //Scene escena = SceneManager.LoadScene("Inicio");

        SceneManager.LoadScene("MenuInicial");

           
        //GameObject objeto = GameObject.Find("CanvasMenuInitNew");
        Debug.Log("cambio a selecccion");
        menuManager.MenuSelectCharacter();
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(6);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
    }

    public IEnumerator Winner()
    {
        yield return new WaitForSeconds(8);
        winnerPanel.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
    }



    //public void Quit()
    //{
    //    Debug.Log("Se cierra el juego");
    //    audioSource.Stop();
    //    //StartCoroutine(LoadMainMenu());
    //    //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    //    SceneManager.LoadScene("Main Menu (Mobile) 1");
    //    Time.timeScale = 1f;
    //    //SceneManager.SetActiveScene(SceneManager.LoadScene("Main Menu(Mobile) 1"));
    //    //Application.Quit();
    //}
    //
    //private IEnumerator LoadMainMenu()
    //{
    //    //cinematic.Play();
    //    yield return new WaitForSeconds(0.1f);
    //    SceneManager.LoadScene("Main Menu (Mobile) 1");
    //}
}