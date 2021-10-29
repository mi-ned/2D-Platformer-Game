using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Similar to the bill class, this time it uses rubies

public class token : MonoBehaviour
{
    public float tokenValue; //the value of the ruby
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D other){ //if the player touches the rubies
        if(other.gameObject.CompareTag("Player")){ 
            AudioSource.PlayClipAtPoint(sound,transform.position);
            tokenManager.instance.ChangeScore(tokenValue); //the score gets added by 1 (by calling the token manager class)
        }
    }
}