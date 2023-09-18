using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar_UI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image  healthbar_front_image; //obrazok pre healthbar
    public void Update_Healthbar(Health_control health_Control)
    {
        healthbar_front_image.fillAmount = health_Control.Remaining_Health_Percentage; // urcuje dlzku healthbaru voci percentu zostavajucemu zivotu
    } 
}
