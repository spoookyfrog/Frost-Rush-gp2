using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargobyebye : MonoBehaviour
{
    public Rigidbody myRB;
    public GameObject myPlayer;
    float positionX;
    float positionY;
    float positionZ; 
    // Start is called before the first frame update
    void Start()
    //position of the revive point
    {
        positionX = 39.68f;
        positionY = 4.77f;
        positionZ = -1029.63f;
        myPlayer = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")

        {
            myRB.transform.position = new Vector3(positionX, positionY, positionZ); //will find player's location and bring it to the checkpoint i made
        }
    }
}
