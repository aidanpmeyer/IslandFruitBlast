using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour { 

    public TMP_Text textTimer;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 60f;
        textTimer.text = "Time Remaining: " + timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        textTimer.text = "Time Remaining: " + (Mathf.Round(timeLeft)).ToString();
        
    }
}
