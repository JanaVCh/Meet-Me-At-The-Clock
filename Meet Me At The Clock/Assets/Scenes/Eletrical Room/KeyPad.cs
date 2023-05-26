using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KeyPad : MonoBehaviour
{
    [SerializeField] private Text Ans;

    private string Answer = "1912";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }


    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "VALID";
            SceneManager.LoadScene("Electrical Panel");
        }
        else
        {
            Ans.text = "ERROR";
        }
    }

    public void Delete()
    {
        Ans.text = null;
    }
}   