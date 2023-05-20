using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int amountEnemyes = 1; // Esto es igual a cero !! ESTO NO ME LO SABIA
    private int countWaves = 1;
    private bool enter = false;
    private SpawnEnemyManager waves;
    [HideInInspector] public MenuGamePlay menuGamePlay; 
    // Start is called before the first frame update
    void Start()
    {

        waves = GameObject.Find("EnemyPooling").GetComponent<SpawnEnemyManager>();
        waves.InstanceEnemyWave(countWaves);
        amountEnemyes = countWaves;
        //StartCoroutine(InstanciateWavesWithTime());
        //InvokeRepeating("InstanciateWaves",10,10);
        menuGamePlay = FindObjectOfType<MenuGamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        // InstanciateWaves();
        // if (can == 0 && entro == false) // 0 && true

        if(countWaves == 3)
        {
            Debug.Log("Winner");
            if (menuGamePlay != null)
            {
                StartCoroutine(menuGamePlay.Winner());
                //menuGamePlay.Winner();
            }
        } else if(amountEnemyes == 0 && !enter)
        {
            StartCoroutine(InstanciateWavesWithTime());
        }
    }

    IEnumerator InstanciateWavesWithTime()
    {
        enter = true;
        yield return new WaitForSeconds(5);
        countWaves++; // = 2
        amountEnemyes = countWaves; // 2

        waves.InstanceEnemyWave(countWaves);
        enter = false;
    }
}
