using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosManager : MonoBehaviour
{
    public GameObject[] Cinematics;
    private new Animator animation;

    public AudioSource EpicMusic;

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

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[7].GetComponent<Animator>();
        animation.SetBool("isActive", true);
        animation = Cinematics[8].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(7.8f);
        animation = Cinematics[9].GetComponent<Animator>();
        animation.SetBool("isActive", true);

        yield return new WaitForSeconds(8.3f);
        EpicMusic.Stop();

        yield return new WaitForSeconds(1f);
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MenuInicial");
    }

}

