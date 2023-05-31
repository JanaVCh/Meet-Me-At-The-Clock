using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNewScene : MonoBehaviour
{
    string newScene;

    private void Awake()
    {
        newScene = "Username";
    }
    public void OnMouseDown()
    {

        SceneManager.LoadScene(newScene);
    }
}
