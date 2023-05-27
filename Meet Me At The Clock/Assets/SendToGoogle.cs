using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    public GameObject Q4;
    public GameObject Q5;
    public GameObject Q6;

    private string Qu1;
    private string Qu2;
    private string Qu3;
    private string Qu4;
    private string Qu5;
    private string Qu6;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLScDaB5yxHDXYh6WcdS988tlfeEi1ARkus38jhDNSOTIg2q1rg/formResponse";

    IEnumerator Post(string Q1, string Q2, string Q3, string Q4, string Q5, string Q6)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1708840237", Q1);
        form.AddField("entry.1291013981", Q2);
        form.AddField("entry.1147518131", Q3);
        form.AddField("entry.577269528", Q4);
        form.AddField("entry.1575773879", Q5);
        form.AddField("entry.1906268743", Q6);

        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("www.error");
            }
            else
            {
                Debug.Log("Success");
            }
        }
    }

    public void Send()
    {
        Qu1 = Q1.GetComponent<InputField>().text;
        Qu2 = Q2.GetComponent<InputField>().text;
        Qu3 = Q3.GetComponent<InputField>().text;
        Qu4 = Q4.GetComponent<InputField>().text;
        Qu5 = Q5.GetComponent<InputField>().text;
        Qu6 = Q6.GetComponent<InputField>().text;

        StartCoroutine(Post(Qu1, Qu2, Qu3, Qu4, Qu5, Qu6));
    }


}
