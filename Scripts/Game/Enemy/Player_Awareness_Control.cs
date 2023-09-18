using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Awareness_Control : MonoBehaviour
{
    public bool Aware_of_Player { get; private set; }
    //zistuje ci je nepriatel vedomi si hraca v okolí
    //je public aby ostatné skripty k nej mali prístup
    //iba tento skript moze urcit hodnotu

    public Vector2 Direction_to_Player { get; private set; }
    //vektor ku hracovi

    [SerializeField]
    private float Player_Awareness_Distance;
    //Kazdemu nepriatelovi vieme nastavit rozdielnu vzdialenost kedy zacne vnimat hraca

    private Transform player;
    //udrzi nam poziciu hraca



    
    private void Awake()//volana iba raz
    {
        player = FindObjectOfType<Player_Movement>().transform;
        //zisti nam poziciu hraca

    }

   
    void Update()
    {

        Vector2 Enemy_to_Player_vector = player.position - transform.position;//Vektor nam urcuje ako daleko je hrac, a akym smerom

        Direction_to_Player =  Enemy_to_Player_vector.normalized; //normalized nastavi rozsah na 1 a zachovava smer, pretoze nepotrebujeme rozsah vektora

        if (Enemy_to_Player_vector.magnitude <= Player_Awareness_Distance) // zistujeme ci je hrac v "zornom poli" nepriatela pomocou magnitude,co nam dava rozsah vektora
        {
            Aware_of_Player = true;
        }
        else {Aware_of_Player = false; }
 
    }
}
