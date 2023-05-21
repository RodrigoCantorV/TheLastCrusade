using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image lifeBar;
    public float currentLife;
    //public float 
    [SerializeField] private CharacterBase characterBase;

    // Update is called once per frame
    void Update()
    {
        LifeManagement();
    }

    public void LifeManagement()
    {
        //currentLife = characterBase.life - 20f;
        lifeBar.fillAmount = currentLife / characterBase.life;
    }
}
