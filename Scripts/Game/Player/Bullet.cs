using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //pri kolizii strely s hocijakym inym objektom sa strela znici
    }

}
