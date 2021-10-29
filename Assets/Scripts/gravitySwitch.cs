using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=hX70SNM_XWI
//This class was specifically designed for the boss level. It allows the players to switch gravity, every time they jump;

public class gravitySwitch : MonoBehaviour
{
    private Rigidbody2D myRB; //a ridigidbody is required
    private bool top; //determines whether or not the player is on the top of the level (and is upside down)
    private playerController2 player; //due to design flaws (in which the isJumping element  interferes 
    //and the non-existent shooting elements in playerController, i've made a script specifically for the player in the final level

    void Start() {
        player = GetComponent<playerController2>(); //gets the player component
        myRB =   GetComponent<Rigidbody2D>(); //gets the player's rigidbody component
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){ //if the space button is pressed
            myRB.gravityScale *= -1; //the gravity scale is set to gravityscale multiplied by -1
            Rotation(); //rotation method is called
        }
    }

    void Rotation() {
        if(top == false){ //if the top boolean variable is false...
            transform.eulerAngles = new Vector3(0,0,180f); //the player's avatar switches upside down
        }
        else { //if the opposite is true
            transform.eulerAngles = Vector3.zero; //then the player is back to normal again
        } 

        player.facingRight = !player.facingRight; //the player then faces his right, but upside down form
          top = !top;
    }
}