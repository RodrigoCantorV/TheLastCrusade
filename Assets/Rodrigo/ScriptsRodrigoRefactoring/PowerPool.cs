using System.Collections.Generic;
using UnityEngine;

public class PowerPool : MonoBehaviour
{
    [SerializeField] private GameObject powerPrefab;
    [SerializeField] private int poolZise = 3;
    [SerializeField] private List<GameObject> powerList;
    public bool createPowers = true;

    // Patron singleton
    //private static PowerPool instance;
    //public static PowerPool Instance { get { return instance; } }
    private void Awake()
    {


      //  if (instance == null)
      //  {
      //      instance = this;
     //   }
     //   else
     //   {
      //      Destroy(gameObject);
     //   }
    }
    private void FixedUpdate()
    {
        if (createPowers)
        {
            addPowersToPool(poolZise);
        }
        createPowers = false;

    }

    private void addPowersToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject power = Instantiate(powerPrefab, gameObject.transform);
            power.SetActive(false);
            powerList.Add(power);
            // power.transform.parent = gameObject.transform;
        }
    }

    public GameObject RequestPower()
    {
        for (int i = 0; i < powerList.Count; i++)
        {
            if (!(powerList[i].activeSelf))
            {
                powerList[i].SetActive(true);
                return powerList[i];
            }
        }
        addPowersToPool(1);
        powerList[powerList.Count - 1].SetActive(true);
        return (powerList[powerList.Count - 1]);
    }
}