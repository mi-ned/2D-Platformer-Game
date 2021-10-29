using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Reference: https://www.youtube.com/watch?v=26d1uZ7yrfY
//This class switches levels once the player completes any given level (with the exception of the final boss)
public class levelController : MonoBehaviour
{
    public int index; //an index is assigned to a scene pending on what is the index number according to the scene manager
    public string LevelName; //whatever the chapter name of that level is
   public  AudioClip sound; //assigns a sound effect

    void OnTriggerEnter2D(Collider2D other){ //if the player enters the end zone then a new scene will be loaded
            if(other.tag == "Player"){
                AudioSource.PlayClipAtPoint(sound,transform.position);

                SceneManager.LoadScene(index);
                SceneManager.LoadScene(LevelName);
        }
    }
}