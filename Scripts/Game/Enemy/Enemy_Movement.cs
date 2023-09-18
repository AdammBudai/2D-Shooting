using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    //Kazdemu nepriatelovi mozeme menit rychlost pohybu, otacania a jeho zivot
    [SerializeField]
    private float Enemy_Speed;

    [SerializeField]
    private float Enemy_Rotation_Speed;

    [SerializeField]
    private float Enemy_Health;
    



    private Rigidbody2D rb; // odkaz na komponent, aby sme nim mohli pohybovat
    private Player_Awareness_Control player_awareness_control; //odkaz na skript zistujuci ci je hrac v okoli nepriatela
    private Vector2 target_direction; //obsahuje smer ciela


    private float change_direction_cooldown;
   
    private void Awake()
    {
        // priradenie skriptov
        rb = GetComponent<Rigidbody2D>();
        player_awareness_control = GetComponent<Player_Awareness_Control>();
    }
    
    
    private void FixedUpdate() //FixedUpdate sa vyuziva na fyzikalne vypocty kvoli vyssej frekvencii
    {
        Player_Targeting();
        Rotate_to_Target();
        Set_Velocity();
    }

    
    private void OnCollisionEnter2D(Collision2D collision) //pri kolizii nepriatela a objektu s tagom "Bullet" prichadza nepriatel o 10 zivotov
                                                           //Kill_Manager  nam pocita kolko nepriatelov je stale nazive
    {
        if (collision.gameObject.tag == "Bullet")
        {

            Enemy_Health -= 10;
            if(Enemy_Health <= 0) 
            {
                Destroy(gameObject);
                Kill_Manager.live_enemies--;

            }

        }

    }


   

    private void Player_Targeting() //ak je hrac v okoli nepriatela, ziskame jeho smer, inak je nulovy
    {
        if (player_awareness_control.Aware_of_Player)
        {
            target_direction = player_awareness_control.Direction_to_Player;
        }
        else
        {
            target_direction = Vector2.zero;
        }

    }

    private void Rotate_to_Target()
    {
        // vytvara quaternionovu hodnotu neskor pouzitu na nastavenie cielovej rotacie objektu.
        // transfom.forward predstavuje smer objektu ktoremu kod patri
        // target_direction je vektor urcujuci cielový smer, ktory chceme dosiahnut
        Quaternion target_rotation = Quaternion.LookRotation(transform.forward, target_direction); 

        //otocenie sa k cielu
        //pre maximalny uhol pouzijeme rychlost otacania vynasobenu casom aby sme zaistili otacanie v stale rovnakej rychlosti bez ohladu na fps.
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, Enemy_Rotation_Speed * Time.deltaTime);

        //aplikujeme otacanie na rigidbody2d
        rb.SetRotation(rotation);


    }

    private void Set_Velocity()
    {
        if (target_direction == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * Enemy_Speed; //pohyb v smere kde sa pozera nepriatel(up) urcenou ruchlostou
        }
    }
}
