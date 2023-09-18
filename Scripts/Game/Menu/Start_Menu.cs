using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_Menu : MonoBehaviour
{
    //na zaciatku hry sa nastavi pocet zozbieranych minci na 0 a posunie dalsiu scenu
    public void Start_Game()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetFloat("collected_coins", 0);
    }
}
