using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class startGameScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public void OnClick()
    {
        PlayerPrefs.SetString("Username", inputField.text);
        SceneManager.LoadScene("Prologue");
    }
}
