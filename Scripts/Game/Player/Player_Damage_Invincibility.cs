using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Damage_Invincibility : MonoBehaviour
{
    [SerializeField]
    private float Invincibility_Duration;

    private Invincibility_controller invincibility_Controller;

    private void Awake()
    {
        
        invincibility_Controller = GetComponent<Invincibility_controller>();
    }
    public void Start_Invincibility() // zacne nezranitelnost trvajucu urcity cas
    {
        invincibility_Controller.StartInvincibility(Invincibility_Duration);
    }
}
