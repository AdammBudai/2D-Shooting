using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Menu : MonoBehaviour
{
    public GameObject dead_menu;
    
    void Start()
    {
        dead_menu.SetActive(false);   //na zaciatku je false aby nebolo zjavene
    }

    public void PlayerDead()// pri smrti hraca a zjavi deadmenu, hra sa zastavi
    {
        dead_menu.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
