using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=g-ku3I-Ts7Y&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=26
//This class controlls the snowball that is getting shot

public class shootSpore : MonoBehaviour
{
    public GameObject theProjectile; //the snowball object
   public float shootTime; //the time it takes to shoot the snowball
   public int chanceShoot; //random shooting moment
    public Transform shootFrom; //where the snowball is being shot from
    float nextShootTime; //the next time that the cannon will shoot
    void Start() {
        nextShootTime = 0f; //shoot time is set to 0 as default
    }

    void OnTriggerStay2D(Collider2D other){ //if the snowball pops out
        if(other.tag=="Player"&&nextShootTime < Time.time){ //if the player approaches the trigger zone
            nextShootTime = Time.time+shootTime; //the shot is executed
            if(Random.Range(0,10)>=chanceShoot){ //the number that ranges from 0 to 10 but higher than the chance shoot number, the snowball will go in a random direction
                Instantiate(theProjectile,shootFrom.position,Quaternion.identity);
            }
        }
    }
}