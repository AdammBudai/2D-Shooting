using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Coin_Manager cm; //zabezpeci nam zber a aktualizovanie najdenych minci

    [SerializeField]
    private AudioSource find_effect; // priradenie zvukoveho efektu
    private int hidden_coins = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(hidden_coins < 2) //kazda truhlica obsahuje 2 skryte mince, je do nej potrebne 2krat narazit
            {
                //zber ukrytych minci v truhlici
                cm.Collect();
                find_effect.Play();
                hidden_coins++;
            }
            
        }

    }
}
