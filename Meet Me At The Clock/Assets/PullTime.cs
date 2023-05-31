using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTime : MonoBehaviour
{

    public string RoomNumber;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        time = PlayerPrefs.GetFloat("Time", 0);
        PlayerPrefs.SetFloat(RoomNumber, time);
        Debug.Log(RoomNumber +": " + PlayerPrefs.GetFloat(RoomNumber, 0).ToString());
    }
}
