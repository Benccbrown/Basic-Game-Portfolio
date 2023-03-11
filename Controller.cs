using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //below are all the variables used
    public float movementSpeed = 5f;
    public float acceleration = 0f;
    public float maxSpeed = 7f;
    public float jumpForce = 5f;
    public float clockwise = 100f;
    public float antiClockwise = -100f;
    private bool touchingPlatform = false;
    private Rigidbody playerRigidBody;
    CharacterController controller;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();
        //below locks the cursor in the middle like an fps game
        Cursor.lockState = CursorLockMode.Locked;

    }
    void OnCollisionEnter (Collision c)
    { //if the player is colliding with an object, touchingPlatform is true
	    touchingPlatform = true;
    }
 
    void OnCollisionExit (Collision c)
    {// if the player isn't colliding with an object, touchingPlatofrm is false
	    touchingPlatform = false;
    }



    void Update()
    {

        if (touchingPlatform)
        {
            //when the touchingPlatform is true, the player can jump
            if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
            }
        }
        //if the w key is pressed...
        if (Input.GetKey (KeyCode.W))
        {   // they move forward per second by their movement speed and acceleration
            transform.position += transform.forward * Time.deltaTime * movementSpeed * acceleration;
            if (movementSpeed + acceleration < maxSpeed)
            { //if their movement speed and acceleration dont equal maxSpeed, then acceleration increases
                acceleration =+ acceleration + 0.01f;
            }
        }   //if the s key is pressed...
        else if (Input.GetKey (KeyCode.S))
        {   // the character moves backwards
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
        // if the d key is pressed...
        if(Input.GetKey(KeyCode.D))
        { // they move to the right 100*
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        } // if the a key is pressed...
         else if(Input.GetKey(KeyCode.A))
        { //they move to the left 100*
            transform.Rotate(0, Time.deltaTime * antiClockwise, 0);
        }
        // this gets the position of the mouse coordinates so I can rotate with the mouse
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        transform.Rotate(y, x, 0);
        Screen.lockCursor = true;
    }
}
