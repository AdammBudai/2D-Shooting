using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Player_Movement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 movement_input;
    private Vector2 smooth_movement_input;
    private Vector2 smooth_movement_input_velocity;

    [SerializeField]
    private float movement_speed; //rychlost pohybu
    [SerializeField]
    private float rotation_speed; //rychlost otacania

    public Coin_Manager cm; //pre zber micni

    [SerializeField]
    private AudioSource collect_effect; // zvuk na pozbieranie

    private void OnTriggerEnter2D(Collider2D collision) // pri kolizii hraca s mincou  sa znici minca, prida sa k pozbieranym a prehra sa zvuk
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            cm.Collect();
            collect_effect.Play();

        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //aby sme mohli hybat objektom
    }
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        smooth_movement_input = Vector2.SmoothDamp(smooth_movement_input, movement_input,
            ref smooth_movement_input_velocity, 0.1f); //zabezpecuje plynuly pohyb

        rb.velocity = smooth_movement_input * movement_speed; //urcuje rychlosù hraca v smere kde je otoceny
    } 

    private void RotateInDirectionOfInput()
    {
        if(movement_input != Vector2.zero)
        {
            // vytvara quaternionovu hodnotu neskor pozitu na nastavenie cielovej rotacie objektu.
            Quaternion target_rotation = Quaternion.LookRotation(transform.forward, smooth_movement_input);

            //otocenie sa k cielu
            //pre maximalny uhol pouzijeme rychlost otacania vynasobenu casom aby sme zaistili otacanie v stale rovnakej rychlosti bez ohladu na fps.
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }

    }


    private void OnMove(InputValue input_value)// vola sa ak je tlacidlo stisknute, tlacidlo musi byt prepojene s akciou pohybu
    {
        movement_input = input_value.Get<Vector2>();
    }
}
