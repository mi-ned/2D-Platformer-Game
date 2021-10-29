using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References: https://www.youtube.com/watch?v=w5g-opP3jp8&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=12
//This class determins what happens to a specific charachter (boss) when the rocket hits them. 
//Originally, it was going to be a rocket, but I've changed it to a bullet.

public class rocketHit : MonoBehaviour
{
    public float weaponDamage; //determins how much damage a weapon can do
    gunController myPC; //calls the gun controller class
    public GameObject explosionEffect; //contains the animations for the smoke and explosions

    void Awake() { //whenever the gun gets shot, the gun controller gets called
        myPC = GetComponentInParent<gunController>();
    }

    void OnTriggerEnter2D(Collider2D other) { //whenever the gun is fired and makes contact with the shootable layer...
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable")){ //bullet is incoming to the shootable layer
            myPC.removeForce(); //bullet stops
            Instantiate(explosionEffect, transform.position, transform.rotation); //explosion effect gets instantiated
            Destroy(gameObject); //bullet is destroyed
            if(other.tag == "Boss"){ //if the boss is shot...
                bossHealth hurtBoss = other.gameObject.GetComponent<bossHealth>(); //boss health class is called
                hurtBoss.addDamage(weaponDamage); //damage gets added to the boss
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) { //if the bullet lands on the shootable layer...
             if(other.gameObject.layer == LayerMask.NameToLayer("Shootable")){ //bullet is incoming to the shootable layer
            myPC.removeForce(); //bullet stops
            Instantiate(explosionEffect, transform.position, transform.rotation); //explosion effects get instantiated
            Destroy(gameObject); //bullet is destroyed
              if(other.tag == "Boss"){
                enemyHealth hurtBoss = other.gameObject.GetComponent<enemyHealth>(); //boss health class is called
                hurtBoss.addDamage(weaponDamage); //damage gets added to the boss
            }
        }
    }
}