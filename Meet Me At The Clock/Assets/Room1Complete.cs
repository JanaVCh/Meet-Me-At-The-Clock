using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room1Complete : MonoBehaviour
{
    public GameObject TimerManager;
    private Timers


    public void takeTime()
    {
        //realTime = float.Parse(Timer.text);

        PlayerPrefs.SetFloat("Room1Time", PlayerPrefs.GetFloat("Time", 100));
        
    }


}