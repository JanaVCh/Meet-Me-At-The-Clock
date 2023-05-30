using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{

    public float timeValue = 1804;
    public Text timeText;
    private float countdownTime = 30 * 60; // 30 minutes in seconds

    private void Start()
    {
        DisplayTime(timeValue);
    }

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            DisplayTime(timeValue);
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

    }

    public void SubtractTime()
    {
        countdownTime -= 90; // Subtract 90 seconds
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;

        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

