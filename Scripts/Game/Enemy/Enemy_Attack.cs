using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [SerializeField]
    private float damage_amount; //kazdemu nepriatelovi vieme urcit ake bude mat poskodenie voci hracovi

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Movement>())
        {
            //pri kolizii objektu obsahujuceho skrip Player_Movement 
            // do Health_control ulozime Health_control skript na zisaknie pristupu k hracovmu zivotu
            var Health_control = collision.gameObject.GetComponent<Health_control>();
            Health_control.Take_Damage(damage_amount); //z Health_control volame funkciu, ktora odcita urcite mnozstvo zivota
        }
        
    }
    
}
