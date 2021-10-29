using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//References: 
//https://www.youtube.com/watch?v=AD4JIXQDw0s
//https://github.com/Brackeys/Boss-Battle
//This class controlls the final boss's health, as well as how it dies.
public class bossHealth : MonoBehaviour
{
	public float bossMaxHealth; //The highest amount of health that the boss can have
	public GameObject bossDeathFX; //When the boss dies, blood will splatter around
	public Slider bossSlider; //A GUI element that shows the boss' health
	public bool drops; //Whether or not the boss drops something once dead
	public GameObject theDrop; //Once the boss dies, a key will be dropped
	public bool isInvulnerable = false; //checks to see whether or not the boss is damageable
    float  bossCurrentHealth; //The health of the boss before, during and after
	public float bossAngerHealth; //When the boss reaches a threshhold of health, the enemy will change behaviour
	public AudioClip hurtSound; //When the boss gets shot, he'll make a sound
	public AudioClip deathSound; //When the boss dies, then there'll be a splattering sound

	void Start() {
		bossCurrentHealth = bossMaxHealth; //The currentHealth starts off with the maximum possible health
		bossSlider.maxValue = bossCurrentHealth; //The GUI is set to the maximum health
		bossSlider.value = bossCurrentHealth; //The GUI value is set to whatever health the boss is in
	}

	public void addDamage(float bossDamage)
	{
		if (isInvulnerable) { //If the boss is NOT invulnerable, the player cannot kill the boss, hence why it's switched on
			return;
		}

		bossSlider.gameObject.SetActive(true); //The GUI element is activated
		bossCurrentHealth -= bossDamage; //Where damage gets inflicted, the boss' current health decreases with the value of the boss damage
		AudioSource.PlayClipAtPoint(hurtSound,transform.position); //A hurt sound will be played whenever the boss gets shot
		bossSlider.value = bossCurrentHealth; //Where damage gets inflicted, the boss' GUI decreases with the value

		if (bossCurrentHealth <= bossAngerHealth) { //if the the boss' health reaches a certain threshold...
			GetComponent<Animator>().SetBool("IsEnraged", true); //the boss changes charachter going in an all out assault
		}

		if (bossCurrentHealth <= 0)	{ //if the boss' health reaches 0
			makeBossDead(); //the make dead method is called
		}
	}

	void makeBossDead() {
		AudioSource.PlayClipAtPoint(deathSound,transform.position); //A death sound will be played once the boss dies
		Destroy(gameObject); //the boss gets destroyed
		Instantiate(bossDeathFX, transform.position, Quaternion.identity); //blood will sputter all over the map
		if(drops) Instantiate(theDrop, transform.position, transform.rotation); //the boss will drop a key, in which the player must collect
	}
}
