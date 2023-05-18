using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpawnEnemyManager waves;
    // Start is called before the first frame update
    void Start()
    {
        waves = GameObject.Find("EnemyPooling").GetComponent<SpawnEnemyManager>();
        waves.InstanceEnemyWave(2);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
