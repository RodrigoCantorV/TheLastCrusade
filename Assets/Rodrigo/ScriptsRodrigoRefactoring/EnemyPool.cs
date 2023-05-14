using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyesPrefabs;
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

        AddEnemyToPool(poolSize);
    }

    void Start()
    {

    }

    private void AddEnemyToPool(int amount)
    {
        // Creamos las instancia por cada enemigo
        for (int i = 0; i < enemyesPrefabs.Count; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                GameObject myEnemy = Instantiate(enemyesPrefabs[i]);
                myEnemy.SetActive(false);
                enemyList1.Add(myEnemy);
                myEnemy.transform.parent = this.gameObject.transform;
            }
        }
    }

    public GameObject RequestEnemy(string tag)
    {
        for (int i = 0; i < enemyList1.Count; i++)
        {
            if (!(enemyList1[i].activeSelf) && enemyList1[i].CompareTag(tag))
            {
                enemyList1[i].SetActive(true);
                return enemyList1[i];
            }
        }
        return null;
    }
}
