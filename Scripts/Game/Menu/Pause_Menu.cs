using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pause_menu;
    
    public static bool paused;

    

    public void Pause()// pozastavi hru
    {
        pause_menu.SetActive(true); // zjavi sa pause_menu
        Time.timeScale = 0f; // hra prestane bezat
        paused = true;
    }

    public void Resume()// zrusi pozastavenie hry
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void To_Main_Menu()//prenesie hraca do hlavneho menu nacitanim sceny Main Menu
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("Main Menu");
        
    }
    
    void Start()
    {
        pause_menu.SetActive(false); //pause menu nastavi na zaciatku na false aby nebolo zobrazene 

    }

    
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.P))  //pri stlaceni "p" ´pozastavi hru a zobrazi pause menu
        {
            if(paused)
            {
                Resume();
            }
            else { Pause();}

        }
    }

}
