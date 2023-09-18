using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility_controller : MonoBehaviour
{
    private Health_control health_control;

    public void Awake()
    {
        health_control= GetComponent<Health_control>();// priraduje Health_control do premennej na urcovanie nezranitelnosti
    }
    public void StartInvincibility(float Invincibility_Duration)
    {
        StartCoroutine(Invincibility_CoRoutine(Invincibility_Duration));
    }
    //zaistuje hracovy docasnu nezranitelnost
    private IEnumerator Invincibility_CoRoutine(float Invincibility_Duration)
    {
        health_control.isInvincible = true;
        yield return new WaitForSeconds(Invincibility_Duration);//pozastavuje korutinu na zadany pocet sekund, potom sa hrac stava zranitelnym
        health_control.isInvincible = false;
    }
}

