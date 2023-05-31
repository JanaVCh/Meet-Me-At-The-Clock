using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class SendLeaderboard : MonoBehaviour
{
    [SerializeField] InputField Username;
    private float Room1;
    private float Room2;
    private float Room3;
    private float totalTime;

    string URL = "https://docs.google.com/forms/d/1Vh61x_-W5UjyAWHmsUpdOKnCwS7_3IA1r42n8J1xiXw/formResponse";

    public void OnMouseDown()
    {
        totalTime = PlayerPrefs.GetFloat("TotalTime", 0);
        Room1 = PlayerPrefs.GetFloat("Room1Time", 0);
        Room2 = PlayerPrefs.GetFloat("Room2Time", 0);
        Room3 = PlayerPrefs.GetFloat("Room3Time", 0);

        StartCoroutine(Post(Username.text, totalTime.ToString(), Room1.ToString(), Room2.ToString(), Room3.ToString()));
    }


    IEnumerator Post(string s1, string totalTime, string Room1, string Room2, string Room3)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.315825453", s1);
        form.AddField("entry.1106318438", totalTime);
        form.AddField("entry.526760649", Room1);
        form.AddField("entry.1887297910", Room2);
        form.AddField("entry.1183969348", Room3);


        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }
}