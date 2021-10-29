using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=gdMsKyPuv-U&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=31
//This class makes sure that the player reaches the end zone properly
public class spawnDoor : MonoBehaviour
{
    bool activated = false; //the door is deactivated at first
    public Transform whereToSpawn; //spawn is set up
    public GameObject door; //the door is set up

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && !activated){
            activated = true;
            Instantiate(door, whereToSpawn.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
