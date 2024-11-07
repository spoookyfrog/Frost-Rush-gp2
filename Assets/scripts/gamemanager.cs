using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class gamemanager : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    
    public TextMeshProUGUI timerText, recordText;
    public float timer = 0f, record;
    public bool timerRunning = false;
    public GameObject racer;
    public void StartTimer ()
    {
        timerRunning = true;
        Debug.Log("Timer started"); // Debug message
    }
    public void StopTimer ()
    {
        timerRunning = false;

        if (timer > record || record == 0f)
        {
            record = timer;
            PlayerPrefs.SetFloat("record", record);
        }
        DisplayRecord(record);
    }
    

    public void DisplayRecord(float _record)
    {
        float minutes = Mathf.FloorToInt(_record / 60);
        float seconds = Mathf.FloorToInt(_record % 60);
        float milisecs = Mathf.FloorToInt((_record * 1000f) % 1000f);

        recordText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milisecs);
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //locks mouse pointer to the screen

        if (PlayerPrefs.HasKey("record"))
        {
            record = PlayerPrefs.GetFloat("record");
        }
        else
        {
            record = 0f;
        }

        DisplayRecord(record);
    
    }
    void FixedUpdate()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
            //Debug.Log("Timer running good: " + timer);
        }
        else 
        {
            DisplayTime(timer);
        }
    }

    void DisplayTime(float timeToDisplay) //timerUI is good
    {
        if (timerText != null)

        {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milisecs = Mathf.FloorToInt((timeToDisplay * 1000f) % 1000f);
        
        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milisecs);

        }

        else 

        {
        //Debug.LogError("timerText UI element is not assigned in the Inspector.");
        }
    }
}
