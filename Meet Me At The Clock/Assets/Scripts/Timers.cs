using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Fungus;
using UnityEngine.SceneManagement;



public class Timers : MonoBehaviour
{
    
    public static bool timerActive = true;
    public static float currentTime = 30;
    public float startMinutes;
    public TextMeshProUGUI timerText;
    public static bool firstTime = true;
    public static string time;
    public Flowchart flowchart;
    public static string room;
    public TextMeshProUGUI timeText;
    public static int Room1;
    public static bool Hint1Used;
    public static bool Hint2Used;
    public static bool Hint3Used;
    public static bool Act2Hint1Used;
    public static bool Act2Hint2Used;
    public static bool Act2Hint3Used;
    public static bool Act3Hint1Used;
    public static bool Act3Hint2Used;
    public static bool Act3Hint3Used;
 

    public static bool ElHint1Used;
    public static bool ElHint2Used;
    public static bool ELHint3Used;
    public static bool ELAct2Hint1Used;
    public static bool ElAct2Hint2Used;
    public static bool ElAct2Hint3Used;
    public static bool ELAct3Hint1Used;
    public static bool ELAct3Hint2Used;
    public static bool ElAct3Hint3Used;

    public static bool StHint1Used;
    public static bool StHint2Used;
    public static bool StHint3Used;
    public static bool StAct2Hint1Used;
    public static bool StAct2Hint2Used;
    public static bool StAct2Hint3Used;
    public static bool StAct3Hint1Used;
    public static bool StAct3Hint2Used;
    public static bool StAct3Hint3Used;

    public static bool Survey;
    public static string TimeLeft;

    public static bool Puzzle1Completed;
    public static string Puzzle1Time;
    public static bool Puzzle2Completed;
    public static string Puzzle2Time;
    public static bool Puzzle3Completed;
    public static string Puzzle3Time;
    public static int TempGameCompletionTime;
    public static string GameCompletionTime;
    public static int Puzzle1Hints = 0;
    public static string Puzzle2Hints = "0";
    public static string Puzzle3Hints = "0";
    public static bool GameOver;

    private void Start()
    {
        currentTime = PlayerPrefs.GetFloat("Time", 1800);
    }

    void Update()
    {

        if (PlayerPrefs.GetInt("pause", 0) == 1)
        {
            Debug.Log("waiting");
        }
        else if (timerActive == true && PlayerPrefs.GetInt("pause", 0) == 0)
        {
            PlayerPrefs.GetFloat("Time", currentTime);
            currentTime = currentTime - Time.deltaTime;
            PlayerPrefs.SetFloat("Time", currentTime);
            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = 0;
                Debug.Log("Timer finished");
                SceneManager.LoadScene("Survey");
            }
        }
        
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        if (time.Seconds < 10)
        {
            timeText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        }
        else
        {
            timeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }

        Survey = flowchart.GetBooleanVariable("Survey");

        if (Survey == true)
        {
            timerActive = false;
            TimeLeft = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("TimeLeft", TimeLeft);

            //these next two lines show how to make it so that it shows how many seconds it took instead of how many seconds left
            //we might either want this on the other 3 puzzle or we can just have it for game completion
            TempGameCompletionTime = 1800 - Mathf.RoundToInt(currentTime);
            GameCompletionTime = TempGameCompletionTime.ToString();
            flowchart.SetStringVariable("GameCompletionTime", GameCompletionTime);
        }
        
        Puzzle1Completed = flowchart.GetBooleanVariable("Puzzle1Completed");
        CheckPuzzle1Completion();

        Puzzle2Completed = flowchart.GetBooleanVariable("Puzzle2Completed");
        CheckPuzzle2Completion();

        Puzzle3Completed = flowchart.GetBooleanVariable("Puzzle3Completed");
        CheckPuzzle3Completion();

    }

    private void Awake()
    {
        if (firstTime == true)
        {
            Debug.Log("FirstTime");
            currentTime = startMinutes * 60;
            firstTime = false;
            InvokeRepeating("OutputTime", 1f, 1f);
        }
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

    void CheckPuzzle1Completion()
    {
        if (Puzzle1Completed == true & Puzzle1Time == null)
        {
            Puzzle1Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle1Time", Puzzle1Time);
        }
    }

    void CheckPuzzle2Completion()
    {
        if (Puzzle2Completed == true & Puzzle2Time == null)
        {
            Puzzle2Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle2Time", Puzzle2Time);
        }
    }

    void CheckPuzzle3Completion()
    {
        if (Puzzle3Completed == true & Puzzle3Time == null)
        {
            Puzzle3Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle3Time", Puzzle3Time);
        }
    }

    void OutputTime()
    {
        time = timeText.text;
        Debug.Log(time);
        TimeLeft = Mathf.RoundToInt(currentTime).ToString();
        Debug.Log(TimeLeft);
    }

    //CabinRoom
    //Anagram Puzzle

    public void Act1Hint1()
    {
        Hint1Used = flowchart.GetBooleanVariable("Hint1Used");
        
        if (Hint1Used == true)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Hint1Used = false;
            flowchart.SetBooleanVariable("Hint1Used", Hint1Used);
        }
    }

    public void Act1Hint2()
    {
        Hint2Used = flowchart.GetBooleanVariable("Hint2Used");

        if (Hint2Used == true)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);


            Hint2Used = false;
            flowchart.SetBooleanVariable("Hint2Used", Hint2Used);
        }
    }

    public void Act1Hint3()
    {
        Hint3Used = flowchart.GetBooleanVariable("Hint3Used");

        if (Hint3Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Hint3Used = true;
            flowchart.SetBooleanVariable("Hint3Used", Hint3Used);
        }
    }

    //Flower Pot Puzzle

    public void Act2Hint1()
    {
        Act2Hint1Used = flowchart.GetBooleanVariable("Act2Hint1Used");

        if (Act2Hint1Used == false)
        {
            Puzzle2Hints = "1";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act2Hint1Used = true;
            flowchart.SetBooleanVariable("Act2Hint1Used", Act2Hint1Used);
        }
    }

    public void Act2Hint2()
    {
        Act2Hint2Used = flowchart.GetBooleanVariable("Act2Hint2Used");

        if (Act2Hint2Used == false)
        {
            Puzzle2Hints = "2";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act2Hint2Used = true;
            flowchart.SetBooleanVariable("Act2Hint2Used", Act2Hint2Used);
        }
    }

    public void Act2Hint3()
    {
        Act2Hint3Used = flowchart.GetBooleanVariable("Act2Hint3Used");

        if (Act2Hint3Used == false)
        {
            Puzzle2Hints = "3";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act2Hint3Used = true;
            flowchart.SetBooleanVariable("Act2Hint3Used", Act2Hint3Used);
        }
    }


    public void subtractTime()
    {
        currentTime -= 60;
    }

    //Jigsaw Puzzle

    public void Act3Hint1()
    {
        Act3Hint1Used = flowchart.GetBooleanVariable("Act3Hint1Used");

        if (Act3Hint1Used == false)
        {
            Puzzle3Hints = "1";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act3Hint1Used = true;
            flowchart.SetBooleanVariable("Act3Hint1Used", Act3Hint1Used);
        }
    }
    public void Act3Hint2()
    {
        Act3Hint2Used = flowchart.GetBooleanVariable("Act3Hint2Used");

        if (Act3Hint2Used == false)
        {
            Puzzle3Hints = "2";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act3Hint2Used = true;
            flowchart.SetBooleanVariable("Act3Hint2Used", Act3Hint2Used);
        }
    }
    public void Act3Hint3()
    {
        Act3Hint3Used = flowchart.GetBooleanVariable("Act3Hint3Used");

        if (Act3Hint3Used == false)
        {
            Puzzle3Hints = "3";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);

            currentTime = PlayerPrefs.GetFloat("Time", currentTime);
            currentTime -= 60;
            PlayerPrefs.SetFloat("Time", currentTime);

            Invoke("Wait1", 0.1f);

            Act3Hint3Used = true;
            flowchart.SetBooleanVariable("Act3Hint3Used", Act3Hint3Used);
        }
    }

    //Electrical Room

    //Keypad Puzzle

    public void ElAct1Hint1()
    {
        Hint1Used = flowchart.GetBooleanVariable("ElHint1Used");

        if (Hint1Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("ElPuzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint1Used = true;
            flowchart.SetBooleanVariable("ElHint1Used", Hint1Used);
        }
    }

    public void ELAct1Hint2()
    {
        Hint2Used = flowchart.GetBooleanVariable("Hint2Used");

        if (Hint2Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint2Used = true;
            flowchart.SetBooleanVariable("Hint2Used", Hint2Used);
        }
    }

    public void ElAct1Hint3()
    {
        Hint3Used = flowchart.GetBooleanVariable("Hint3Used");

        if (Hint3Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint3Used = true;
            flowchart.SetBooleanVariable("Hint3Used", Hint3Used);
        }
    }

    //Wires Puzzle

    public void ElAct2Hint1()
    {
        Act2Hint1Used = flowchart.GetBooleanVariable("Act2Hint1Used");

        if (Act2Hint1Used == false)
        {
            Puzzle2Hints = "1";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 60;
            Act2Hint1Used = true;
            flowchart.SetBooleanVariable("Act2Hint1Used", Act2Hint1Used);
        }
    }

    public void ElAct2Hint2()
    {
        Act2Hint2Used = flowchart.GetBooleanVariable("Act2Hint2Used");

        if (Act2Hint2Used == false)
        {
            Puzzle2Hints = "2";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint2Used = true;
            flowchart.SetBooleanVariable("Act2Hint2Used", Act2Hint2Used);
        }
    }
    public void ElAct2Hint3()
    {
        Act2Hint3Used = flowchart.GetBooleanVariable("Act2Hint3Used");

        if (Act2Hint3Used == false)
        {
            Puzzle2Hints = "3";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint3Used = true;
            flowchart.SetBooleanVariable("Act2Hint3Used", Act2Hint3Used);
        }
    }

    //MorseCode Puzzle

    public void ElAct3Hint1()
    {
        Act3Hint1Used = flowchart.GetBooleanVariable("Act3Hint1Used");

        if (Act3Hint1Used == false)
        {
            Puzzle3Hints = "1";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint1Used = true;
            flowchart.SetBooleanVariable("Act3Hint1Used", Act3Hint1Used);
        }
    }
    public void ElAct3Hint2()
    {
        Act3Hint2Used = flowchart.GetBooleanVariable("Act3Hint2Used");

        if (Act3Hint2Used == false)
        {
            Puzzle3Hints = "2";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint2Used = true;
            flowchart.SetBooleanVariable("Act3Hint2Used", Act3Hint2Used);
        }
    }
    public void ElAct3Hint3()
    {
        Act3Hint3Used = flowchart.GetBooleanVariable("Act3Hint3Used");

        if (Act3Hint3Used == false)
        {
            Puzzle3Hints = "3";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint3Used = true;
            flowchart.SetBooleanVariable("Act3Hint3Used", Act3Hint3Used);
        }
    }

    //Maze Puzzle

    public void StAct1Hint1()
    {
        Hint1Used = flowchart.GetBooleanVariable("Hint1Used");

        if (Hint1Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint1Used = true;
            flowchart.SetBooleanVariable("Hint1Used", Hint1Used);
        }
    }
    public void StAct1Hint2()
    {
        Hint2Used = flowchart.GetBooleanVariable("Hint2Used");

        if (Hint2Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint2Used = true;
            flowchart.SetBooleanVariable("Hint2Used", Hint2Used);
        }
    }
    public void StAct1Hint3()
    {
        Hint3Used = flowchart.GetBooleanVariable("Hint3Used");

        if (Hint3Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint3Used = true;
            flowchart.SetBooleanVariable("Hint3Used", Hint3Used);
        }
    }

    //Blackout Puzzle

    public void StAct2Hint1()
    {
        Act2Hint1Used = flowchart.GetBooleanVariable("Act2Hint1Used");

        if (Act2Hint1Used == false)
        {
            Puzzle2Hints = "1";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 60;
            Act2Hint1Used = true;
            flowchart.SetBooleanVariable("Act2Hint1Used", Act2Hint1Used);
        }
    }
    public void StAct2Hint2()
    {
        Act2Hint2Used = flowchart.GetBooleanVariable("Act2Hint2Used");

        if (Act2Hint2Used == false)
        {
            Puzzle2Hints = "2";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint2Used = true;
            flowchart.SetBooleanVariable("Act2Hint2Used", Act2Hint2Used);
        }
    }
    public void StAct2Hint3()
    {
        Act2Hint3Used = flowchart.GetBooleanVariable("Act2Hint3Used");

        if (Act2Hint3Used == false)
        {
            Puzzle2Hints = "3";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint3Used = true;
            flowchart.SetBooleanVariable("Act2Hint3Used", Act2Hint3Used);
        }
    }

    //Combo Lock Puzzle

    public void StAct3Hint1()
    {
        Act3Hint1Used = flowchart.GetBooleanVariable("Act3Hint1Used");

        if (Act3Hint1Used == false)
        {
            Puzzle3Hints = "1";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint1Used = true;
            flowchart.SetBooleanVariable("Act3Hint1Used", Act3Hint1Used);
        }
    }
    public void StAct3Hint2()
    {
        Act3Hint2Used = flowchart.GetBooleanVariable("Act3Hint2Used");

        if (Act3Hint2Used == false)
        {
            Puzzle3Hints = "2";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint2Used = true;
            flowchart.SetBooleanVariable("Act3Hint2Used", Act3Hint2Used);
        }
    }
    public void StAct3Hint3()
    {
        Act3Hint3Used = flowchart.GetBooleanVariable("Act3Hint3Used");

        if (Act3Hint3Used == false)
        {
            Puzzle3Hints = "3";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint3Used = true;
            flowchart.SetBooleanVariable("Act3Hint3Used", Act3Hint3Used);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("Time", currentTime);
    }

    private void Wait1()
    {
        PlayerPrefs.SetInt("pause", 0);
    }
}
