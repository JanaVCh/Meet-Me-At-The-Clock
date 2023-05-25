using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TurnOnDrawerClick : MonoBehaviour
{
    private bool beingheld = false;
    private void OnMouseDown()
    {
        beingheld = true;

    }

    public void Open()
    {
        if (beingheld == true)
        {
            SceneManager.LoadScene("Drawer View");
        }
    }
}