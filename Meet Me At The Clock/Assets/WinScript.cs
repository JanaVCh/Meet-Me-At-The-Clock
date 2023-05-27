using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myPieces;

    void Start()
    {
        pointsToWin = myPieces.transform.childCount;
    }

    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            // WIN
            SceneManager.LoadScene("Drawer View");


        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
