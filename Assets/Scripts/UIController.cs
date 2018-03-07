using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text text;

    float timerCount;
    float timerStart; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        #region GameTimer

        timerCount = Time.time - timerStart;
        timerStart = Time.time - timerCount;

        float seconds = Mathf.Floor(timerCount % 60);
        float minutes = Mathf.Floor(timerCount / 60);


        //Text Ausgabe
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        #endregion

    }
}
