using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=c-NTQ5RqUtE&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=23
//This class picks up any remains of a dead enemy or boss
public class healthPickup : MonoBehaviour
{
    public float healthAmount; //gives the player a health boost

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){ //if the player collects the remains
            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>(); //the player's health class is called
            theHealth.addHealth(healthAmount); //the health amount gets added
            Destroy(gameObject); //the object is destroyed
        }
    }
}