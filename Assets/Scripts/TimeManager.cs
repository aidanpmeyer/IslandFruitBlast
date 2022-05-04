using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour { 

    public TMP_Text textTimer;
    public float timeLeft;
    private bool grabbed;
    private AudioSource timerclip;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 120f;
        textTimer.text = "Time Remaining: " + timeLeft.ToString();
        grabbed = false;
        timerclip = GameObject.Find("Text Time").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed){
            timeLeft -= Time.deltaTime;
            textTimer.text = "Time Remaining: " + (Mathf.Round(timeLeft)).ToString();

        }
        if (timeLeft == 0)
        {
            timerclip.Play();
            textTimer.text = "Times up!";

        }
        if (timeLeft <= 0)
        {
            textTimer.text = "Times up!";
            
        }
        
        
    }

    public void Setgrab()
    {
        grabbed = true;
    }
}
