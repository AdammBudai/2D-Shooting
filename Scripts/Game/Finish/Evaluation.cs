using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Evaluation : MonoBehaviour
{
    public TMP_Text evaluation;

    private void Update()
    {
        //ziska pocet zozbieranych minci z PlayerPrefs a vypise uspesnost
        float score = PlayerPrefs.GetFloat("collected_coins");
        evaluation.text = "Your score was " + ((score/10)*100).ToString() + "%";
        
    }
    


}
