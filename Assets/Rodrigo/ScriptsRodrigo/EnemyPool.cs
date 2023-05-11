using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private List<GameObject> enemyList1;
    private int poolSize = 10;

    // Atributos para el patrón singleton
    private static EnemyPool instance;
    public static EnemyPool Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AddEnemyToPool(poolSize);
    }

    private void AddEnemyToPool(int amount)
    {
        // Creamos las instancias de los enemigos
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy1 = Instantiate(enemyPrefab1);
            enemy1.SetActive(false);
            enemyList1.Add(enemy1);
            enemy1.transform.parent = this.gameObject.transform;
        }
    }
}
