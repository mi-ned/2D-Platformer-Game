using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=5I_XHcsO3Oc&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=22
//This class determines how much damage an enemy would be able to make to the player
public class enemyDamage : MonoBehaviour
{    
    public float damage; //damage number determines how much damage one enemy can cause
    public float damageRate; //damage rate determines how much damage one enemy can cause at a certain time
    public float pushBackForce; //push pack force determines how much distance a player gets pushed back
    float nextDamage; //Determines when the next damage will take

    void Start() {
        nextDamage = 0f; //next damage starts off with 0 by default
    }

        void OnTriggerEnter2D(Collider2D other) { //if the trigger is entered by the player. This means that the player can jump on the enemy and kill them
        if(other.tag=="Player"){
            playerController player = other.gameObject.GetComponent<playerController>(); //the player controller script is called
            if (player.isJumping == true){ //if the player is jumping, the enemy health class is called and adds damage to the enemy
                enemyHealth healthEnemy = GetComponent<enemyHealth>();
                healthEnemy.addDamage(damage);
            }
        }
    }   

    void OnTriggerStay2D(Collider2D other) { //if the trigger is still active by the player
        if(other.tag == "Player" && nextDamage<Time.time){ //if the tag is player and next damage is lesser than the time it took for the damage to be delivered
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //grabs the player's health by calling the playerHealth class
            thePlayerHealth.addDamage(damage); //adds the damage to the player
            nextDamage = Time.time + damageRate; //next damage is set to damage rate plus the time it took for damage to occur
            pushBack(other.transform); //push back method gets called
        }
    }

    void pushBack(Transform pushedObject){
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized; //pushes the player back by having a new Rigidbody and more force
        pushDirection*=pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
