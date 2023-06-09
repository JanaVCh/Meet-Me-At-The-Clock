using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WireCount : MonoBehaviour
{
    static public WireCount Instance;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
            // Change Scene
            SceneManager.LoadScene("Side View 1");
        }
    }
}
