using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is a damage for the player whenever he hits the boulder. 
//Due to design flaws, I've made this script similar to the enemyDamage class, minus the isjumping boolean

public class boulderDamage : MonoBehaviour
{
    public float damage; //sets the damage value
    public float damageRate; //sets the rate of damage
    public float pushBackForce; //sets the push back force that the player could experience
    float nextDamage; //sets the next damage time to a certain number to prevent multiple damages in one go
    void Start() {
        nextDamage = 0f; //As default, the next damage is set at 0
    }

    void OnTriggerStay2D(Collider2D other) { //If the trigger is activated
        if(other.tag == "Player" && nextDamage<Time.time){ //if the boulder makes contact with the player AND the next damage is less than time
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //player health class gets called
            thePlayerHealth.addDamage(damage); //damage is added to the player, thus loses some health
            nextDamage = Time.time + damageRate; //as damage is being done, the next damage is calculated by the time it took for the damage to be done
            pushBack(other.transform); //push back method is called
        }
    }

    void pushBack(Transform pushedObject) { //once the boulder makes contact, the player gets pushed back left or right depending on the position.
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection*=pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}