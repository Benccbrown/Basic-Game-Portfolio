using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //these are all variables which will be used.
    public float movementSpeed = 2f;
    public float jumpForce = 2f;
    public float clockwise = 100f;
    public float antiClockwise = -100f;
    public bool touchingPlatform = true;
    private Rigidbody playerRigidBody;
    CharacterController controller;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        controller = GetComponent<CharacterController>();

    }
    //if the player is colliding with an object, then touchingPlatform is true.
    void OnCollisionEnter (Collision c) 
    {
	    touchingPlatform = true;
    }
    //if the player is colliding with an object, then touchingPlatform is false.
    void OnCollisionExit (Collision c) 
    {
	    touchingPlatform = false;
    }


    void Update()
    {
        //when touchingPlatform is true...
        if (touchingPlatform == true) 
        {
            //and the space bar or left mouse button is pressed...
            if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            { //the players height increases using the variable jumpForce
                playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
            }
        }
        // if the w key is pressed....
        if (Input.GetKey (KeyCode.W))
        {    //move the characters position forward over time to the power of their speed.
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        // if the s key is pressed...
        else if (Input.GetKey (KeyCode.S))
        {   //move the characters position backwards over time to the power of their speed.
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
        //if the d key is pressed...
        if(Input.GetKey(KeyCode.D)) { //rotate 100* clockwise
             transform.Rotate(0, Time.deltaTime * clockwise, 0);
         }//if the s key is pressed...
         else if(Input.GetKey(KeyCode.A)) { //rotate -100* cockwise
             transform.Rotate(0, Time.deltaTime * antiClockwise, 0);
         }



        // playerRigidBody.MovePosition(transform.position + movement);
    }
}
