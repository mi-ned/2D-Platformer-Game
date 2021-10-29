using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References: 
//https://www.youtube.com/watch?v=AD4JIXQDw0s
//https://github.com/Brackeys/Boss-Battle
//This class controlls the final boss.

public class bossController : MonoBehaviour
{
    public Transform player; //The Transform detects the player
	bool isFlipped = false; //This boolean sets the isFlipped to false. This means that the boss will start the level facing left.
	public AudioClip sound; //Whenever the boss switches direction, the boss will make a switch sound
    
	public void LookAtPlayer(){
		if(player == null){ //If the player dies, then the boss will stop looking at the player. Without this verification, an exception error will be thrown
			return;
		}
		
		Vector3 flipped = transform.localScale; //This vector3 checks to see whether or not the player is standing on a platform
		flipped.z *= -1f; //flipped is set to "z *= -1f". This indicates whether or not the player is alive or not

		if (transform.position.x > player.position.x && isFlipped) { //if the player is on the right side of the map and it's flipped...
			AudioSource.PlayClipAtPoint(sound,transform.position); //plays the switch audio
			transform.localScale = flipped; //the boss will follow into the player's direction
			transform.Rotate(0f, 180f, 0f); //the boss will rotate depending on where the player is
			isFlipped = false; //the isFlipped boolean is set to false
		}
		
		else if (transform.position.x < player.position.x && !isFlipped) {//if the player is on the left side of the map and it's NOT flipped...
			AudioSource.PlayClipAtPoint(sound,transform.position); //plays the switch audio
			transform.localScale = flipped; //the boss will follow into the player's direction
			transform.Rotate(0f, 180f, 0f); //the boss will rotate depending on where the player is
			isFlipped = true; //as a result, the isFlipped boolean is set to true
		}
	}
}
