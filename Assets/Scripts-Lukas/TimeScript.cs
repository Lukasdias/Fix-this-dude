using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text textoTimer;
    public float tempoRestante = 60f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decrementaTempoRestante", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
         if (tempoRestante <= 0f){
             tempoRestante = 0f;
        }
        
        textoTimer.text = tempoRestante + " Seconds remaining!";
    }

    void decrementaTempoRestante()
    {
        tempoRestante--;
    }

    public IEnumerator Timer(){
        yield return null;
    }
}
