using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemigo;
    Enemy[] enemigos;
    public static int can = 1; // Esto es igual a cero !! ESTO NO ME LO SABIA
    public int countWaves = 1;
    public int cantidadEnemigos;

    public static bool esCero = false;

    public SpawnEnemyManager waves;
    // Start is called before the first frame update
    void Start()
    {

        waves = GameObject.Find("EnemyPooling").GetComponent<SpawnEnemyManager>();
        waves.InstanceEnemyWave(countWaves);
       // StartCoroutine(popo());

    }


    // Update is called once per frame
    void Update()
    {
        enemigos = enemigo.GetComponentsInChildren<Enemy>();
        Debug.Log(enemigos.Length);
        //Invoke("InstanciateWaves",10);
          if (enemigos.Length == 0)
        {
            countWaves ++;
            waves.InstanceEnemyWave(countWaves);
        }

    }

    void InstanciateWaves()
    {
        if (enemigos.Length == 0)
        {
            countWaves ++;
            waves.InstanceEnemyWave(countWaves);
        }



    }
    IEnumerator popo()
    {
        yield return new WaitForSeconds(12);
        InstanciateWaves();
    }
}
