using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public List<GameObject> positions;
    //public int amountWave;

    public int waveBaseEnemy2;
    public int waveBoosEnemy1;
    // Start is called before the first frame update
    void Start()
    {
        //InstanceEnemyWave(amountWave);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstanceEnemyWave(int amountWave)
    {
        for (int i = 0; i < amountWave; i++)
        {
            int positionCube = Random.Range(0, positions.Count);
            GameObject enemy = EnemyPool.Instance.RequestEnemy("EnemyBase1");
            enemy.transform.position = positions[positionCube].transform.position;
            CapsuleCollider collider = enemy.gameObject.GetComponent<CapsuleCollider>();
            if (collider != null)
            {
                // Desactiva el CapsuleCollider
                collider.enabled = true;
            }
        }

        if ((amountWave % waveBaseEnemy2) == 0)
        {
            int amountEnemiBase2 = amountWave / waveBaseEnemy2;
            for (int i = 0; i < amountEnemiBase2; i++)
            {
                int positionCube = Random.Range(0, positions.Count);
                GameObject enemy = EnemyPool.Instance.RequestEnemy("EnemyBase2");
                enemy.transform.position = positions[positionCube].transform.position;
                CapsuleCollider collider = enemy.gameObject.GetComponent<CapsuleCollider>();
                if (collider != null)
                {
                    // Desactiva el CapsuleCollider
                    collider.enabled = true;
                }
            }
        }

        // Instanciar enemigos
        if ((amountWave % waveBoosEnemy1) == 0)
        {
            int amountEnemiBoss = amountWave / waveBoosEnemy1;
            for (int i = 0; i < amountEnemiBoss; i++)
            {
                int positionCube = Random.Range(0, positions.Count);
                GameObject enemy = EnemyPool.Instance.RequestEnemy("EnemyBoss1");
                enemy.transform.position = positions[positionCube].transform.position;
                CapsuleCollider collider = enemy.gameObject.GetComponent<CapsuleCollider>();
                if (collider != null)
                {
                    // Desactiva el CapsuleCollider
                    collider.enabled = true;
                }
            }
        }
    }
}
