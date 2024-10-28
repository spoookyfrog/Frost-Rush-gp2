using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcheckpoint1 : MonoBehaviour
{
    public gamemanager handler;
    public GameObject racer;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundtrigger = GetComponent<Collider>();
    }
    
        void OnTriggerEnter(Collider collider)
        {
             //Debug.Log("Trigger entered by: car ");
            if (racer = GameObject.FindGameObjectWithTag("Player"))
            {
                handler.StartTimer();
            }

            source.Play();
            
        }

        AudioSource source;
        Collider soundtrigger;
}
