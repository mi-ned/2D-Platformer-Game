using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This class manages the rubies (similar to billsManager class)
public class tokenManager : MonoBehaviour
{
    public static tokenManager instance; //the token manager instance is set so that it can count the amount of rubies
    public TextMeshProUGUI rubyCounter; //the rubies get tallied up and an on screen graphic shows how many rubies are there
    float text; //text is there to convert the GUI text to text
    float score; //the score is there to tell the player how many rubies that they've collected

    void Start() {
        score = 0; //score starts at 0
        if (instance == null){ //if instance is null, then the game won't crash
            instance = this;
        }
    }
 
    public void ChangeScore(float billValue){ //the scores will change once a ruby has been collected
         score += billValue; //if a player collects one ruby, they will receive x amount of coins
        rubyCounter.text = score.ToString() + " / 5"; //the player can see how many diamonds they have
    }
 }