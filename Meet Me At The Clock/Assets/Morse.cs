using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Morse : MonoBehaviour
{
    public InputField Passwordinput;

    private string Answer = "meet me at the clock";

    public void ChekcPasswordCondition()
    {

        string ReceivedString = Passwordinput.text;

        if (ReceivedString == Answer)
        {
            Debug.Log("Allow");
            SceneManager.LoadScene("Side View 2");
            print("Meet me at the clock? WHat Does that mean? ");
        }
        else
        {
            Debug.Log("Dont Allow");

        }
    }
}
