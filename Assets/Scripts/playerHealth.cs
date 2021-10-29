using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//References: https://www.youtube.com/watch?v=LC-ZXi7XXks&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=16
//This class determines the livelyhood of the player
public class playerHealth : MonoBehaviour
{
    public float playerMaxHealth; //sets the maximum player health
    public GameObject playerDeathFX; //player death affects are set once the player dies

    public restartGame theGameManager; //whenever the player dies, the game restarts
    float playerCurrentHealth; //the health of the player
    playerController controlMovement; //playerController class

    public Slider playerHealthSlider; //activates a GUI for the player to indicate what health he's in
    public Image damageScreen; //whenever the player is damaged, the player will see a screen
    bool damaged = false; //determines if the player got hit
   Color damagedColour = new Color(250f,0f,0f,0.5f); //changes the color of the image to red
   float smoothColor = 5f; //refers to how smooth the image should be
   public AudioClip deathSound; //When a player dies, then there'll be a splattering sound
       public AudioClip hurtSound; //When a player gets harmed, they'll make a sound
       public AudioClip victorySound;
   public Text gameOverScreen; //GUI text set to remind the player that they've died
   public Text winGameScreen; //GUI text set to remind the player that they've won the game

    void Start() {
        playerCurrentHealth=playerMaxHealth;  //The currentHealth starts off with the maximum possible health
        controlMovement = GetComponent<playerController>(); //Gets the player controller
        playerHealthSlider.maxValue=playerMaxHealth;  //The GUI is set to the maximum health
        playerHealthSlider.value=playerMaxHealth;  //The GUI value is set to whatever health the player is in
        damaged = false;
    }

    void Update() {
        if(damaged){ //if the player experiences harm, then the damage screen appears
            damageScreen.color = damagedColour;
        } else{ //otherwise, the screen remains invisible
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
        }
        damaged = false; //and damage is set to false to stop further damage
    }

    public void addDamage(float damage){
        if(damage<=0) return; //if damage is less than 0, then the GUI will be set to default
        playerCurrentHealth -= damage; //Where damage gets inflicted, the player current health decreases with the value of the player damage
        playerHealthSlider.value = playerCurrentHealth; ////Where damage gets inflicted, the player's GUI decreases with the value
        damaged = true; 
        if(playerCurrentHealth<=0){ //if the players health reaches 0
            makePlayerDead(); //the make dead method is called
        }
    }

    public void addHealth(float healthAmount){ //if the player picks up any remains from a dead animal, then the health increases, rather than decreases
        playerCurrentHealth += healthAmount;
        if(playerCurrentHealth > playerMaxHealth) playerCurrentHealth = playerMaxHealth; //if the current health is equal to max player health...
        playerHealthSlider.value = playerCurrentHealth; //the health bar will be full
    }
    
    public void makePlayerDead(){ //if the player dies...
        Instantiate(playerDeathFX, transform.position, transform.rotation); //the spluttering affect will be applied
        Destroy(gameObject); //game object gets destroyed
        AudioSource.PlayClipAtPoint(deathSound,transform.position); //sound is played
        damageScreen.color = damagedColour; //damage screen gets played
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>(); //animation plays
        gameOverAnimator.SetTrigger("gameOver"); //text reminding them that they've died
        theGameManager.restartTheGame(); //game gets restarted by calling the game manager class
    }

    public void winGame(){ //if the player wins the final level, then a message will be shown
        Destroy(gameObject); //object will be destroyed
        AudioSource.PlayClipAtPoint(victorySound,transform.position);
        Animator winGameAnimator = winGameScreen.GetComponent<Animator>(); //animation is played (final level only)
        winGameAnimator.SetTrigger("gameOver");
    }
}