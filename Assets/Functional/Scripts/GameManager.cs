using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    // Agregamos singleton para poder llamar facilmente la informacion
    public static GameManager Instance;

    public List<Personajes> personajes;

    private void Awake()
    {
        if(GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
