using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcheckpoint1 : MonoBehaviour
{
    public gamemanager handler;
    public GameObject racer;
    
        public void OnTriggerEnter(Collider other)
        {
             //Debug.Log("Trigger entered by: car ");
            if (racer = GameObject.FindGameObjectWithTag("Player"))
            {
                handler.StopTimer();
            }
            
        }
}