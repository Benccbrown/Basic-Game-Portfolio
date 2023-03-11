using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Triggers : MonoBehaviour
{
    //Creates two game objects with their chosen names
    GameObject[] finishObjects;
    GameObject[] collideObjects;

    void Start()
    {
        // This makes finishObjects apply to any item with the tag "Win"
        finishObjects = GameObject.FindGameObjectsWithTag("Win");

        hideFinished();

        finishObjects = GameObject.FindGameObjectsWithTag("Win2");

        hideFinished2();
        // This makes collideObjects apply to any item with the tag "Collide"
        collideObjects = GameObject.FindGameObjectsWithTag("Collide");


        hideCollided();
    }

    private bool touchingWall = false;
    public bool touchingEgg = false;
    public int eggs = 0;
 
    void OnCollisionEnter(Collision c)
    {//if layer 8 (my wall layer) is collided with, then touchingWall is true.
        if (c.gameObject.layer == 8)
        {
            touchingWall = true;
        }

        //if layer 9 (my EasterEgg layer) is collided with, then touchingWall is true.
        if (c.gameObject.layer == 9)
        {
            touchingEgg = true;
            c.gameObject.SetActive(false);//this and the line below will delete the object when touched
            Debug.Log(c.gameObject.name);
            Points.eggs += eggs = 1; //adds one point to egg
        }
        else
        {
            touchingEgg = false;
        }
    }


    void OnCollisionExit(Collision c)
    {//if layer 8 (my wall layer) is not collided with, then touchingWall is false.
        if (c.gameObject.layer == 8)
        {
            touchingWall = false;
        }
    }



    void Update ()
    {   //if touchingWall is true, the method showCollided runs
	    if (touchingWall == true)
        {
		    showCollided();
	    }
        else
        { //if not, it's still hidden
            hideCollided();
        }
    }
    //shows objects with the Collide tag
    public void showCollided()
    {//if there's objects colliding, then the output is true.
        foreach(GameObject g in collideObjects)
        {
            g.SetActive(true);
        }
    }
    //hides objects with the Collide tag
    public void hideCollided()
    { //if no objects are colliding, then the output is false.
        foreach  (GameObject g in collideObjects)
        {
            g.SetActive(false);
        }
    }
    void OnTriggerEnter (Collider c)
    {
	    if (eggs == 5)
        {
            showFinished2();
        }
        else
        {
            showFinished();
        }
    }

    //shows objects with the End tag
	public void showFinished()
    {
		foreach(GameObject g in finishObjects)
        {
			g.SetActive(true);
		}
	}

    public void showFinished2()
    {
		foreach(GameObject g in finishObjects)
        {
			g.SetActive(true);
		}
	}

	//hides objects with the End tag
	public void hideFinished()
    {
		foreach(GameObject g in finishObjects)
        {
			g.SetActive(false);
		}
	}
    public void hideFinished2()
    {
		foreach(GameObject g in finishObjects)
        {
			g.SetActive(false);
		}
	}
}
