using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject playerSelect;

    // Start is called before the first frame update
    public void StartButton()
    {
        startButton.SetActive(false);
        playerSelect.SetActive(true);
    }



    //public void PlayerSelect()
    //{
    //    playerSelect.SetActive(false);
    //    playerSelect.SetActive(true);
    //}
}
