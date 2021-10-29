using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Reference: https://www.youtube.com/watch?v=j72VC_vlmhQ&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=30
public class restartGame : MonoBehaviour
{
    public float restartTime; //sets the restart time
    bool restartNow = false; //the game restart boolean is set to false at first
    float resetTime; //time it takes to reset the game
    
    void Update() {
        if(restartNow && resetTime <= Time.time){ //if the restart is initiated, then the scene will be loaded to the active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void restartTheGame(){ //the game gets restarted at that moment in time
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
