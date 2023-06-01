using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class uploadTotalTimeToSheets : MonoBehaviour
{
    public float Time;
    public string stringTime;
    public string name;

    private void Awake()
    {
        
    }

    public string URL = "https://docs.google.com/forms/d/1Vh61x_-W5UjyAWHmsUpdOKnCwS7_3IA1r42n8J1xiXw/formResponse";


    public void Set()
    {
        Time = PlayerPrefs.GetFloat("Time", 0);
        name = PlayerPrefs.GetString("Username", "testing");
        stringTime = Time.ToString();
        

        StartCoroutine(Post(name, stringTime));
        Debug.Log("Posted.");
    }

    IEnumerator Post(string n, string t)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.315825453", n);
        form.AddField("entry.1106318438", t);
        Debug.Log("Post Entries");



        var www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

    }
}


   
        

    

