using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Desaparecer(this.gameObject)); 
    }

    IEnumerator Desaparecer(GameObject dropo)
    {
        yield return new WaitForSeconds(8);
        dropo.SetActive(false);
    }
}
