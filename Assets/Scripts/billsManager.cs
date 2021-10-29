using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Referenece: https://www.youtube.com/watch?v=DZ-3g31jk90
//Like the bill.cs script, it was originally going to use bank notes
//This class stores the amount of coins that the player has collected in a level
public class billsManager : MonoBehaviour
{
    public static billsManager instance; //The instance makes sure that this class is visible to the on-screen UI and it's other coins
    public TextMeshProUGUI value; //In order for the on-screen graphics to work, it needs a GUI
    float score; //Keeps track of the amount of coins that one person has

    void Start() {
        score = 0; //The total coins is set to 0 as default
        if (instance == null){ //if the instance is null, then the default on screen value (set in the player GUI) is set. This prevents the graphic from disappearing
            instance = this;
        }
    }
 
 public void ChangeScore(float billValue) { 
     score += billValue; //if the player collects the coin, the bill value's total increases
     value.text = "$ " + score.ToString(); //The player will see the amount of money. They will see " $ 0" for starters
    }
}