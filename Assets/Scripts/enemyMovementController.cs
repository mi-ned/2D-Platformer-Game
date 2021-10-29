using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=5I_XHcsO3Oc&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=22
//This class determines how the enemy behaves

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed; //sets up the enemy speed
    Animator enemyAnimator; //if the enemy gets triggered, certain animations will be played
    public GameObject enemyGraphic; //enemy GUI object
    bool canFlip = true; //whether or not an enemy can flip or not
    bool facingRight = false; //whether or not an enemy is facing right
    float flipTIme = 5f; //the time it takes to switch directions (left or right)
    float nextFlipChance = 0f; //the chance of a flip taking place
    public float chargeTime; //the time it takes to charge
    float startChargeTime; //the time it takes to start the charge time from when the player enters the box collider
    bool charging; //determines whether or not an enemy is charging
    Rigidbody2D enemyRB; //detects an enemies' rigidbody

    void Start() {
        enemyAnimator=GetComponentInChildren<Animator>(); //animator is set to the child of the enemy object
        enemyRB = GetComponent<Rigidbody2D>(); //each rigidbody is located in the parent node of the enemy object
    }

    void Update() {
        if(Time.time > nextFlipChance) { //if time is over the next flip chance variable
            if(Random.Range (0,10) >= 5) flipFacing(); //if a random number between 0 and 10 is over 5, then the enemy will face the direction of the player
            nextFlipChance = Time.time+ flipTIme; //once the random number is set, the flip will be completed based on the time and flip time
        }
    }

    void OnTriggerEnter2D(Collider2D other) { //if the player enters the trigger
        if(other.tag == "Player"){
            if(facingRight && other.transform.position.x < transform.position.x) { //if the player is on the left side of the enemy AND if the enemy is facing left
                flipFacing();
            } 
            else if (!facingRight && other.transform.position.x > transform.position.x) { //if the player is on the right side of the enemy AND if the enemy is facing right
                flipFacing();
            } //each if statement calls the flipFacing method
            
            //these below variables are set to false and true respectively because the box collider has only just been activated
            canFlip = false; 
            charging = true;
            startChargeTime = Time.time + chargeTime; //the enemy starts to charge towards the player
        }
    }
     void OnTriggerStay2D(Collider2D other) { //if the enemy is currently charging at the player
        if(other.tag == "Player"){
            if(startChargeTime < Time.time) { //if the start charge time is less than time, then the enemy will charge towards the player of either side

                if(!facingRight){
                     enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
                }
                else enemyRB.AddForce(new Vector2(1,0)*enemySpeed);

                if (enemyAnimator == true) {
                    enemyAnimator.SetBool("isCharging",charging); //the set charging animation is set to true
                }

                else return; //if there's no charging, then instead of an exeption being thrown, warning messages pop up
        }
    }
}

void OnTriggerExit2D(Collider2D other) { //if the enemy stops charging
    if(other.tag=="Player"){
        canFlip = true; //enemy looks at the player
        charging = false; //charging is set to false
        enemyRB.velocity=new Vector2(0f,0f); //enemy stops charging

        if(enemyAnimator == true) //if the animator happened to be animating (for reasons which the player's in their territory), then the charging motion will still be played
            {enemyAnimator.SetBool("isCharging",charging); 
        }
        else return; //otherwise animation would stop
    }
}
void flipFacing() { //determines the direction that the enemy is facing, depending on where the player is positioned
    if(!canFlip) return; //if the enemy is not clipping, then a return statement is enteted. This prevents any exception errors
    float facingX = enemyGraphic.transform.localScale.x;
    facingX *= -1f;
    enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
    facingRight = ! facingRight;
}
}