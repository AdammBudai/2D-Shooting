using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Shooting : MonoBehaviour
{
    private PlayerInput player_input;
    private InputAction fire;

    [SerializeField]
    private GameObject bullet_prefab;  //vzhlad strely

    [SerializeField]
    private float bullet_speed; //rychlost strely

    [SerializeField]
    private float shot_delay;

    private float last_shot;

    [SerializeField]
    private Transform gun_offset; // miesto odkial vychadzaju strely

    [SerializeField]

    private AudioSource shot_effect; //zvuk pre strelbu

    private void Start()
    {
        player_input= GetComponent<PlayerInput>();
        fire = player_input.actions["Fire"]; // z player input nacitame tlacidla odpvedajuce strielaniu
    }
    void Update()
    {
        if (fire.WasPressedThisFrame())
        {
            float time_since_last_fire = Time.time - last_shot; //zistuje ci hrac moze strielat, ak cas ktorý uplynie od strely prevysuje  shot_delay
            if (time_since_last_fire >= shot_delay )
            {
                if (!Pause_Menu.paused)//pri prerusenej hre zakazuje strielanie
                {
                    Fire_Bullet();
                    last_shot = Time.time;
                }

            }
            
        }
   
    }
    private void Fire_Bullet() //vytvori objekt strely, prida mu telo a rychlost, po vystreleni sa prehra zvuk strelby
    {

        GameObject bullet = Instantiate(bullet_prefab, gun_offset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        shot_effect.Play();

        rb.velocity = bullet_speed * transform.up;
    }

    
}
