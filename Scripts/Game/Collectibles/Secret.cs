using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField]
    private AudioSource find_effect; //poskytne moznost pridat zvukovy efekt
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")  //ak dojde ku kolizi objektu ktoremu prislusi tento skript a objekty s tagom "Player"
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle"); // do zoznamu prekazom prida vsetky objekty s tagom "Obstacle"
            foreach (GameObject obstacle in obstacles)
                GameObject.Destroy(obstacle); //znicenie vsetkych objektov v zozname
            find_effect.Play(); //prehratie zvuku

        }

    }

    


}
