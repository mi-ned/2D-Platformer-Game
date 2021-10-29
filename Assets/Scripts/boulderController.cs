using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=Me6G20rBXvQ
//This class "controlls" the boulder. More specifically, whenever the player triggers the boulder, 
//the boulder will follow the player in a map in which is in normal gravity.

public class boulderController : MonoBehaviour
{
    Rigidbody2D myRB; //Detects whether or not the rigidbody2D is activated on that object
    public AudioClip sound; //Sets up a audio clip sound so that a particular sound plays

    void Start() {
        myRB = GetComponent<Rigidbody2D>(); //the object starts off by setting the component's rigidbody. It's up in the air
    }

    void OnTriggerEnter2D (Collider2D col) { //The first thing that the player will see is the boulder falling down from the sky. 
        if (col.gameObject.tag.Equals("Player")){ //Once the player walks past the box collider the kinematic setting will be switched off
            myRB.isKinematic = false; //The boulder will start chasing the player
            AudioSource.PlayClipAtPoint(sound, transform.position); //Once activated, a boulder rolling down sound will play
        }
    }
}