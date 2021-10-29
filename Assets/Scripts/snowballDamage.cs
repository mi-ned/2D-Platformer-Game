using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Similar to the enemyDamage, bossDamage and playerDamage
//This class makes sure that the snowball in the turret gets damaged
public class snowballDamage : MonoBehaviour
{
    public float damage; //damage is set
    public float damageRate; //damage rate is set
    public float pushBackForce; //push back is done to push the player back when hit
    float nextDamage; //determines when the next damage will be done

    void Start() {
        nextDamage = 0f; //next damage is set at 0
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && nextDamage<Time.time){
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject){
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection*=pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}