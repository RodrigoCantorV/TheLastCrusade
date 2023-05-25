using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] imagenes;
    public static int amountEnemyes = 1; // Esto es igual a cero !! ESTO NO ME LO SABIA
    private int countWaves = 1;
    private bool enter = false;
    private SpawnEnemyManager waves;
    [HideInInspector] public MenuGamePlay menuGamePlay;
    Animator animatorCinematic;
    int ramdom;
    public MenuGamePlay disableUiGame;

    // Start is called before the first frame update
    void Start()
    {

        waves = GameObject.Find("EnemyPooling").GetComponent<SpawnEnemyManager>();
        waves.InstanceEnemyWave(countWaves);
        amountEnemyes = GameObject.Find("EnemyPooling").GetComponentsInChildren<Enemy>().Length;
        //StartCoroutine(InstanciateWavesWithTime());
        //InvokeRepeating("InstanciateWaves",10,10);
        menuGamePlay = FindObjectOfType<MenuGamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        // InstanciateWaves();
        // if (can == 0 && entro == false) // 0 && true

        if (countWaves == 11)
        {
            Debug.Log("Winner");
            if (menuGamePlay != null)
            {
                StartCoroutine(menuGamePlay.Winner());
                //menuGamePlay.Winner();
            }
        }
        else if (amountEnemyes == 0 && !enter)
            Debug.Log(amountEnemyes);
        if (amountEnemyes == 0 && !(enter)) // 0 && true
        {
            ramdom = Random.Range(0, imagenes.Length - 1);
            getCinematic(ramdom);
            StartCoroutine(InstanciateWavesWithTime());
        }
    }

    IEnumerator InstanciateWavesWithTime()
    {
        enter = true;
        yield return new WaitForSeconds(12);
        countWaves++; // = 2
        waves.InstanceEnemyWave(countWaves);
        enter = false;
        amountEnemyes = GameObject.Find("EnemyPooling").GetComponentsInChildren<Enemy>().Length;
    }

    void getCinematic(int numeroCinematica)
    {
        GameObject cinema = imagenes[numeroCinematica].gameObject;
        cinema.SetActive(true);
        animatorCinematic = imagenes[numeroCinematica].GetComponent<Animator>();
        animatorCinematic.SetBool("isActive", true);
        StartCoroutine(pararCinematicas(numeroCinematica));
        StartCoroutine(DesactivarCinematicas(numeroCinematica));
        DisableUI();
        //  Invoke("pararCinematica", 3);
    }

    void DisableUI() {
        menuGamePlay.GetComponent<MenuGamePlay>();
        menuGamePlay.backgroundLife.SetActive(false);
        menuGamePlay.backgroundPowerup.SetActive(false);
    }

    void EnableUI() {
        menuGamePlay.GetComponent<MenuGamePlay>();
        menuGamePlay.backgroundLife.SetActive(true);
        menuGamePlay.backgroundPowerup.SetActive(true);
    }

    /* void pararCinematica()
     {
         animatorCinematic = imagenes[ramdom].GetComponent<Animator>();
         animatorCinematic.SetBool("isActive", false);
     }
 */

    IEnumerator pararCinematicas(int numeroCinematica)
    {
        yield return new WaitForSeconds(2);
        animatorCinematic = imagenes[numeroCinematica].GetComponent<Animator>();
        animatorCinematic.SetBool("isActive", false);
    }

    IEnumerator DesactivarCinematicas(int numeroCinematica)
    {
        yield return new WaitForSeconds(7);
        GameObject cinema = imagenes[numeroCinematica].gameObject;
        cinema.SetActive(false);
        EnableUI();
    }


}
