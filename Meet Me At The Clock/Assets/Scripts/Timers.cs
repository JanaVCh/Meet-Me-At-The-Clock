using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timers : MonoBehaviour
{
    
    public float timeValue = 1800;
    public Text timeText;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;

        }
        else
        {
            timeValue = 0;
        }

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

