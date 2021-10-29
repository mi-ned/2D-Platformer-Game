using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=pWVR3g2PWow&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=11
//This class is based on the projectileController
//Due to design flaws (involving an enemy in an earlier level), I've decided to make a seperate code for the gun in the final level
public class gunController : MonoBehaviour
{
   public float gunSpeed; //determines the speed of the gun once fired
    Rigidbody2D myRB; //detects the rigidbody2d
    
    void Awake() { //the game starts off awake and alert, as the gun is always active and on the ready
        myRB = GetComponent<Rigidbody2D>(); //the rigidbody is activated
         if(transform.localRotation.z>0) { //if the player is facing right (regardless of rotation), then the bullet will travel right..
         myRB.AddForce(new Vector2(-1,0)*gunSpeed, ForceMode2D.Impulse);
        } //or else the bullet will shoot left if the player is facing left
        else myRB.AddForce(new Vector2(1,0)*gunSpeed, ForceMode2D.Impulse);
    }
    public void removeForce(){
        myRB.velocity=new Vector2(0,0); //once the bullet hits its intended target (the boss) the bullet will then come to a halt
    }
}
