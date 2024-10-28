using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool debugs = true;
    public bool onGround;
    public LayerMask whatisGround;
    public Transform groundchecker, frontLEFTwheel, frontRIGHTwheel;
    public Rigidbody myRB;
    public float speedInput, turnInput;
    public float speedup = 10f, speedback = 5f, turningspeed =90f;
    public float gravityforce = -10f; // to put gravity on the car when its in the air
    public float checkRadius = 1f;
    public float drag = 3f; //when the car is on the car
    public float wheelturn = 25f;
    
    // Start is called before the first frame update
    void Start()
    {
        myRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("On Ground: " + onGround + " | Speed Input: " + speedInput);
        //resets the speed input on each frame so it wont build up
        speedInput = 0f;

    if (Input.GetAxis("Vertical") > 0)
    {
        speedInput = Input.GetAxis("Vertical") * speedup * 1000f;
    }

    else if (Input.GetAxis("Vertical") < 0)
    {
        speedInput = Input.GetAxis("Vertical") * speedback * 1000f;
    }

    turnInput = Input.GetAxis("Horizontal");

    //only rotates when the car is on the ground
    if (onGround)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3
        (0f, turnInput * turningspeed * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
    }

    //shows rotation on the front wheels to match which way the car is facing
    frontLEFTwheel.localRotation  = Quaternion.Euler(frontLEFTwheel.localRotation.eulerAngles.x, turnInput 
    * wheelturn, frontLEFTwheel.localRotation.eulerAngles.z);

    frontRIGHTwheel.localRotation  = Quaternion.Euler(frontRIGHTwheel.localRotation.eulerAngles.x, turnInput 
    * wheelturn, frontRIGHTwheel.localRotation.eulerAngles.z);

    transform.position = myRB.transform.position;
    }

    void FixedUpdate() //calls 50 times per frame (no delayed) and best when using psy
    {
        myRB.AddForce(Direction(debugs)*speedup);


        RaycastHit hit;
        //sends an invisbile line down to check if the ground is under the car alongside with the layermask so it only interacts with the groundchecker
        onGround = Physics.Raycast(groundchecker.position, -transform.up, out hit, checkRadius, whatisGround);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        if(onGround)
        {
            myRB.drag = drag; //big drag means slow car on the ground

            if (Mathf.Abs(speedInput) > 0) // mathf.abs means math Absolute and basically makes any number it gets to an positive number
            {
                myRB.AddForce(transform.forward * speedInput);
            }
        }
        else // if the car is in the air then using gravity and not drag
        {
            myRB.drag = 0f;
            myRB.AddForce(Vector3.up * gravityforce * 100f);
        }
    }

    //debug menu... bascially a way to orgainze your debugs and a way to turn them off and on when needed
    Vector3 Direction(bool debugs)
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        if (debugs)
        {
            Debug.DrawRay(transform.position, myRB.velocity, Color.yellow);
            Debug.Log("vector:" + dir);
            Debug.DrawRay(transform.position, dir * 2f, Color.white);
            Debug.DrawRay(groundchecker.position, -transform.up * checkRadius, Color.red);
        }
        return dir;
    }
    
    

}
