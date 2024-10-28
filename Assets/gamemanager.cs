using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Bye bye game");
    }
}
