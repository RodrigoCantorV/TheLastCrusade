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
        yield return new WaitForSeconds(4);
        dropo.SetActive(false);
    }
}
