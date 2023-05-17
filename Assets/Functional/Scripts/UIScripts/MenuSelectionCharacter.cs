using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSelectionCharacter : MonoBehaviour
{
    // Indice de referencia para los personajes
    private int index;

    // Referencia de imagen y nombre
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    //
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("JugadorIndex");

        // Era esta verificacion!
        if(index > gameManager.personajes.Count - 1)
        {
            index = 0;
        }

        ChangeScreen();
    }

    private void ChangeScreen()
    {
        // If de verificacion
        if(index >= 0 && index < gameManager.personajes.Count)
        {
            PlayerPrefs.SetInt("JugadorIndex", index);
            //imagen.sprite = gameManager.personajes[index].imagen;
            //nombre.text = gameManager.personajes[index].nombre;
        } else
        {
            Debug.LogError("Indice fuera de rango: " + index);
        }
    }

    public void NextCharacter()
    {
        if(index == gameManager.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeScreen();
    }

    public void PreviousCharacter()
    {
        if (index == 0)
        {
            index = gameManager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeScreen();
    }

    public void StartGame()
    {
        // Funciona por medio del build setting y el orden de las escenas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
