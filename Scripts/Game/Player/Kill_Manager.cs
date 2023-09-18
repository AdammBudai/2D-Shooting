using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Manager : MonoBehaviour
{

    [SerializeField]
    private int map_enemies; // pocet nepriatelov na mape

    public static int live_enemies; //zijuci nepriatelia

    public  void Kill_enemy() //znizi pocet zijucich nepriatelov
    {
        live_enemies--;
    }

    public static bool  All_Dead() // vriacia true ak su vsetci nepriatelia mrtvy
    {
        if (live_enemies == 0)
        {
            return true;
        }
        else { return false; }
    }


   
    void Start()
    {
        live_enemies = map_enemies; // na zaciatku je pocet zijucich rovny poctu celkovych na mape
    }

    void Update()
    {
        map_enemies = live_enemies;   //potom sa stale aktualizuje pocet nepriatelov na mape 
    }
}
