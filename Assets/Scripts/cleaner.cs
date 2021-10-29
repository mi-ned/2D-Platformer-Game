using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=8EavQJPvz3w&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=28
//This class makes sure that the player or any other objects don't keep on falling forever. If either object hits this, the object will be destroyed
public class cleaner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player") { //If the player falls down
            playerHealth playerFell = other.GetComponent<playerHealth>(); //the player health class will be called
            playerFell.makePlayerDead(); //the player dies
        } 
        else Destroy(other.gameObject); //other objects will be destroyed as well (not just the players)
    }
}
