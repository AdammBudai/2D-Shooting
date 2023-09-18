using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    [SerializeField]
    private AudioSource finish_effect; //priradenie zvukoveho efektu





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")  //pri kolizii s hracom
        {
            if (Kill_Manager.All_Dead()) //Ak su vsetci mrtvy spusti efekt a umozni ukoncit level
            {
                finish_effect.Play();
                Complete_Level();
            }
        }
    }

    private void Complete_Level()//ukoncenie levela nacitanim nasledujucej sceny
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 5);
    }

}
