using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2Complete : MonoBehaviour
{
    public GameObject TimerManager;
    private Timers room1Timer;


    public void takeTime()
    {
        //realTime = float.Parse(Timer.text);
        float timeValue = PlayerPrefs.GetFloat("Time", 100);
        float subtractedValue = 1800 - timeValue;
        PlayerPrefs.SetFloat("Room1Time", subtractedValue);

    }
    public void Start()
    {
        room1Timer = TimerManager.GetComponent<Timers>();

    }


}
