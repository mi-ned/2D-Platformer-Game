using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=gdMsKyPuv-U&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=31
//This class makes sure that when the game is won (final boss level), then the user will see a winning message

public class winGame : MonoBehaviour
{
    public AudioClip sound;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
             AudioSource.PlayClipAtPoint(sound, transform.position);
            playerHealth playerWins = other.gameObject.GetComponent<playerHealth>(); //player health is called
            playerWins.winGame(); //win game method is called
               //Quit Game
                 if (Input.GetKey("escape"))
             Application.Quit();
           
        }
    }
}
