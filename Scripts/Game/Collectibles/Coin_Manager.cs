using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin_Manager : MonoBehaviour
{

    public float coin_counter;
    public void SaveNumber()
    {
        PlayerPrefs.SetFloat("collected_coins", coin_counter); //aktualizovanie zozbieranych minci
    }
    // mince su ulozene do triedy PlayerPrefs, ktora sluzi na ukladanie informacii pocas kazdej sceny
    public void Load_Number()
    {
        coin_counter = PlayerPrefs.GetFloat("collected_coins"); // nacitanie zozbieranych minci
    }
    

    public void Collect() //zber mince
    {
        Load_Number();
        coin_counter++;
        SaveNumber();
    }
    

    public Text coin_text; 
    
    void Start()
    {
        Load_Number();// na zaciatku kazdej sceny nacitame pocet minci z PlayerPrefs aby sme zachovali zobrazeny pocet

    }

   
    void Update()
    {
        coin_text.text = "Coins: " + coin_counter.ToString(); // stale aktualizujeme text urcujuci pocet minci
    }
}
