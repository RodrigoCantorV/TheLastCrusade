using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // private AudioSource audioSource;

	public AudioSource EffectsSource;
	public AudioSource MusicSource;
    public AudioClip GradasSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    public static SoundManager Instance = null;

    /*private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayBackgroundSound", 2f); // Retrasar la reproducci�n del sonido por 2 segundos
        //audioSource.Play(); // Reproducir el sonido de fondo
        //audioSource.Pause(); // Pausar el sonido de fondo
    }*/

    private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}

	public void playSoundBack()
	{
		MusicSource.clip = GradasSound;
		MusicSource.Play();
	}

	public void pauseSoundBack()
	{
		MusicSource.Pause();
	}

    public void playSoundWin()
	{
		EffectsSource.clip = winSound;
		EffectsSource.Play();
	}
    public void playSoundLose()
	{
		EffectsSource.clip = loseSound;
		EffectsSource.Play();
	}

	// Play a single clip through the music source.

    /*private void PlayBackgroundSound()
    {
        //audioSource.Play(); // Reproducir el sonido de fondo
        //audioSource.Pause(); // Pausar el sonido de fondo
    }*/

    //private void Update()
    //{
    //    // Verificar el evento que deseas esperar
    //    if (/* Condici�n del evento */)
    //    {
    //        audioSource.UnPause(); // Reanudar el sonido de fondo si el evento ocurre
    //    }
    //    else
    //    {
    //        audioSource.Pause(); // Pausar el sonido de fondo si el evento no ocurre
    //    }
    //}
}
