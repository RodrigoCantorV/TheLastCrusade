using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    //[SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    //[SerializeField] GameObject weaponSheath;


    GameObject currentWeaponInHand;
    //GameObject currentWeaponInSheath;
    /*void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }*/

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon/*, weaponHolder.transform*/);
        //Destroy(currentWeaponInSheath);
    }

    /*public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        Destroy(currentWeaponInHand);
    }*/

    public void StartDealDamage()
    {
        if (currentWeaponInHand != null)
        {
            Debug.Log("StartDealDamage");
            currentWeaponInHand.GetComponentInChildren<DamageDealer>().StartDealDamage();
        }

    }

    public void EndDealDamage()
    {
        if (currentWeaponInHand != null)
        {
            Debug.Log("StartDealDamage");
            currentWeaponInHand.GetComponentInChildren<DamageDealer>().EndDealDamage();
        }
    }

}
