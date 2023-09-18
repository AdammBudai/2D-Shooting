using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health_control : MonoBehaviour
{
    [SerializeField]
    private float current_health; //udrzuje zostavajuci zivot

    [SerializeField]
    private float max_health; //max zivot

    public float Remaining_Health_Percentage //vracia percentualne zostavajuci zivot
    {

        get
        {
            return current_health / max_health;
        }
    }
    
    public bool isInvincible { get; set; }


    public UnityEvent Died;
    public UnityEvent OnDamage;
    public UnityEvent OnHealthChange;


    public void Take_Damage(float damage_amount)//znizuje hracov zivot a vyvolava funkcie 
    {
        
        if (current_health == 0)
        {
            return;
        }

        if(isInvincible)
        {
            return;
        }

        current_health -= damage_amount;
        ;
        OnHealthChange.Invoke();

        if(current_health < 0)
        {
            current_health = 0;
        }

        if(current_health == 0)
        {
            Died.Invoke();
        }
        else
        {
            OnDamage.Invoke();
        }
    }



}
