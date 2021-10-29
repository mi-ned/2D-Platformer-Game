using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Reference: https://www.youtube.com/watch?v=aMxU654lY6A&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=15
//This class determines the livelihood of the enemies

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth; //sets the maximum enemy health
    public GameObject enemyDeathFX; //enemy death affects are set once the enemy dies
    public Slider enemySlider; //activates a GUI for a specific enemy to indicate what health he's in
    public bool drops; //depending on what enemy is being killed, they'll either drop something or not
    public GameObject theDrop; //Once an enemy dies, something will be dropped (i.e. porkchop for boars)
    public float enemyCurrentHealth; //the status of a particular enemy
    public AudioClip hurtSound; //When an enemy gets shot, they'll make a sound
	public AudioClip deathSound; //When an enemy dies, then there'll be a splattering sound

    void Start()  {
        enemyCurrentHealth = enemyMaxHealth;  //The currentHealth starts off with the maximum possible health
        enemySlider.maxValue = enemyCurrentHealth; //The GUI is set to the maximum health
        enemySlider.value = enemyCurrentHealth; //The GUI value is set to whatever health an enemy is in
    }

    public void addDamage(float damage) {
        enemySlider.gameObject.SetActive(true); //The GUI element is activated
        enemyCurrentHealth -= damage; //Where damage gets inflicted, the enemy current health decreases with the value of the enemy damage
        AudioSource.PlayClipAtPoint(hurtSound,transform.position); //A hurt sound will be played whenever an gets shot
        enemySlider.value = enemyCurrentHealth;  //Where damage gets inflicted, the boss' GUI decreases with the value

        if(enemyCurrentHealth<=0) { //if the enemies health reaches 0
            makeEnemyDead(); //the make dead method is called
        }
    }

    public void makeEnemyDead() {
        Destroy(gameObject.transform.parent.gameObject);  //an enemy gets destroyed
        Instantiate(enemyDeathFX, transform.position, transform.rotation); //blood will splutter all over the area
        if(drops) Instantiate(theDrop, transform.position, transform.rotation); //an enemy will drop a something, in which the player must collect in order stay fit and alive
    }
}