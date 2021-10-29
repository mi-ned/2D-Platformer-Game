using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=DZ-3g31jk90
//Originally the currency was going to use bank notes (hence the class name of bill)
//Instead I've reverted to coins, as the bank notes look rather hideous
//This class reacts whenever someone collects coins
public class bill : MonoBehaviour
{
    public float billValue; //sets the value of the coin
    public AudioClip sound; //plays a money drop sound whenever a coin is collected

    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.gameObject.CompareTag("Player")){  //if the player touches the coin
            AudioSource.PlayClipAtPoint(sound,transform.position); //plays the coin sound
            billsManager.instance.ChangeScore(billValue); //the billsManager instance changes the graphic on the screen
        }
    }
}
