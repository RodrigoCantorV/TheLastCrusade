using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Linea para que aparezca en el menu como opcion de creacion de personaje
[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]
public class Personajes : ScriptableObject
{
    public GameObject personajeJugable;
    //public Sprite imagen;
    //public string nombre;


}
