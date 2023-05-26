using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDrops : MonoBehaviour
{
    [SerializeField] private GameObject[] dropPrefabs;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> dropList;
    private static PoolDrops instance;
    private int dropRamdom;
    public static PoolDrops Instance { get { return instance; } }

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

    private void Start()
    {
        AddDropToPool(poolSize);
    }

    private void AddDropToPool(int amount)
    {
        for (int i = 0; i < dropPrefabs.Length; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                GameObject drop = Instantiate(dropPrefabs[i], this.transform);
                drop.SetActive(false);
                dropList.Add(drop);
            }
        }
    }

    public GameObject RequestDrop()
    {
        for (int i = 0; i < dropList.Count; i++)
        {
            dropRamdom = Random.Range(0,dropList.Count);
            if (!(dropList[dropRamdom].activeSelf))
            {
                dropList[dropRamdom].SetActive(true);
                return dropList[dropRamdom];
            }
        }
        AddDropToPool(1);
        dropList[dropList.Count - 1].SetActive(true);
        return dropList[dropList.Count - 1];
    }
}
