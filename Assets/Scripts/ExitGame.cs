using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitMenu()
    {
        Debug.Log("App quit");
        Application.Quit();
    }
}
