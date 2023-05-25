using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosManager : MonoBehaviour
{
    public GameObject[] Cinematics;
    private new Animator animation;

    private void Start()
    {
        StartCoroutine(NextCinematic());
    }
    IEnumerator NextCinematic()
    {
        yield return new WaitForSeconds(1f);
        animation = Cinematics[0].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[1].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[2].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[3].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[4].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[5].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[6].GetComponent<Animator>();
        animation.SetBool("isActive", true);
    }
}

