using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayBackgroundSound", 2f); // Retrasar la reproducción del sonido por 2 segundos
        //audioSource.Play(); // Reproducir el sonido de fondo
        //audioSource.Pause(); // Pausar el sonido de fondo
    }

    private void PlayBackgroundSound()
    {
        audioSource.Play(); // Reproducir el sonido de fondo
        //audioSource.Pause(); // Pausar el sonido de fondo
    }

    //private void Update()
    //{
    //    // Verificar el evento que deseas esperar
    //    if (/* Condición del evento */)
    //    {
    //        audioSource.UnPause(); // Reanudar el sonido de fondo si el evento ocurre
    //    }
    //    else
    //    {
    //        audioSource.Pause(); // Pausar el sonido de fondo si el evento no ocurre
    //    }
    //}
}
