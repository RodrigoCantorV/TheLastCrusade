using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int amountEnemyes = 1; // Esto es igual a cero !! ESTO NO ME LO SABIA
    private int countWaves = 1;
    private bool enter = false;
    private SpawnEnemyManager waves;
    // Start is called before the first frame update
    void Start()
    {

        waves = GameObject.Find("EnemyPooling").GetComponent<SpawnEnemyManager>();
        waves.InstanceEnemyWave(countWaves);
        amountEnemyes = countWaves;
        //StartCoroutine(InstanciateWavesWithTime());
        //InvokeRepeating("InstanciateWaves",10,10);
    }

    // Update is called once per frame
    void Update()
    {
        // InstanciateWaves();
        // if (can == 0 && entro == false) // 0 && true
        Debug.Log(amountEnemyes);
        if (amountEnemyes == 0 && !(enter)) // 0 && true
        {
            StartCoroutine(InstanciateWavesWithTime());
        }
    }

    IEnumerator InstanciateWavesWithTime()
    {
        enter = true;
        yield return new WaitForSeconds(5);
        countWaves++; // = 2
        waves.InstanceEnemyWave(countWaves);
        enter = false;
        amountEnemyes = GameObject.Find("EnemyPooling").GetComponentsInChildren<Enemy>().Length;
    }
}
