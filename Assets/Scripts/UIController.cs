using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


    public Text text;
    float minutes = 0;
    float seconds = 0;
    float timerCount;
    float timerStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Funktioniert nicht
         /*
         seconds = Mathf.Floor(Time.time % 60);
         minutes = 0;

         if (seconds > 59) minutes += 1;


         //Text Ausgabe
         if(seconds <= 9 && minutes == 0) text.text = "00:0" + seconds.ToString();
         if(seconds >= 10 && minutes == 0) text.text = "00:" + seconds.ToString();
         if(minutes <= 9 && seconds <= 9) text.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
         if(minutes >=10 && seconds <= 9) text.text = minutes.ToString() + ":0" + seconds.ToString();
         if(minutes >=10 && seconds >= 10) text.text = minutes.ToString() + ":" + seconds.ToString();
         */

        //Internet Variante

        timerCount = Time.time - timerStart;
        timerStart = Time.time - timerCount;

        seconds = Mathf.Floor(timerCount % 60);
        minutes = Mathf.Floor(timerCount / 60);

        //Ausgabe
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);




    }
}
