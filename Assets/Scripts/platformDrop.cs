using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=ovsCoNLP05w
//This class makes sure that whatever platform the player steps on, it disappears within a timeframe
public class platformDrop : MonoBehaviour
{
    public Rigidbody2D myRB; //determines if an object is a Rigidbody2D
    public float destroyTime; //the time it takes for an object to destroy, once a player steps on a platform

    void Start() {
        myRB = GetComponent<Rigidbody2D>(); //the rigidbody is activated
    }

    void OnCollisionEnter2D (Collision2D col) { //if the player steps on the platform...
        if(col.gameObject.tag.Equals("Player")){
            Invoke("DropPlatform", 0.5f); //the platform is dropped, within a 0.5 value
            Destroy(gameObject, destroyTime); //the platform gets destroyed
        }
    }
    void DropPlatform(){
         myRB.isKinematic = false; //since the platforms are kinematic (unmovable), the rigidbody's kinematic property is disabled
    }
}