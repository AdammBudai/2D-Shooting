using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    private int scenes = 5;
     public void Quit()
    {
        Application.Quit(); //vypne aplikaciu
    }
    public void Start_Game()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % scenes); // posunie scenu, % modulo 5 lebo sa cheme vratit do hlavneho menu
    }
}
