using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondlife : MonoBehaviour
{
    float positionX;
    float positionY;
    float positionZ;

    void Start()
    {
        positionX = -5.5f;
        positionY = -77.98213f;
        positionZ = -30f;


        transform.position = new Vector3(positionX, positionY, positionZ); 
    }

}
