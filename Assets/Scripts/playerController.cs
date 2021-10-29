using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References
//https://www.youtube.com/watch?v=MvRqEDcJoJQ&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=7
//https://www.youtube.com/watch?v=0-1fhp2kFlY&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=9
//This class is a player controller (for levels 1 and 2) and it enables the player to move

public class playerController : MonoBehaviour
{
    public float maxSpeed; // sets the speed of the player
    bool grounded = false; //whether or not the player is walking or standing still
    float groundCheckRadius = 0.2f; //needs to make sure that player's feet is on the ground
    public LayerMask groundLayer; //this is required in order for the player to even walk or stand on the platform itself
    public Transform groundCheck; //checks to see if the player is above the platform
    public float jumpHeight; //determins how high a player can jump
    Rigidbody2D myRB; //the player has its own rigidbody
    Animator myAnim; //animation charachter
    bool facingRight; //by default, the player will be facing right
    public bool isJumping = false; //a boolean to determine if the player is jumping or not
    
    void Start() {  
       myRB = GetComponent<Rigidbody2D>(); //detects the rigidbody
       myAnim = GetComponent<Animator>(); //detects the animation
       facingRight = true;  //by default, the player will be facing right at the very start of the game
    }

    void Update() {
        if(grounded && Input.GetAxis("Jump")>0){ //if the player jumps
            grounded = false; //grounded and isJumping is set to false and true respectively/ this is so that the animation can work properly
            isJumping = true;
            myAnim.SetBool("isGrounded", grounded); //the animation of isGrounded gets played
            myRB.AddForce(new Vector2(0,jumpHeight)); //the jump is activated
        }
    }

    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer); //the physics2d checks to see if the players in the air or grounded
        myAnim.SetBool("isGrounded",grounded); //the animation is playing
        isJumping = !grounded; //the isJumping boolean is not grounded. the player can kill an enemy
        myAnim.SetFloat("verticalSpeed",myRB.velocity.y); //the vertical speed trigger is applied (in the animation) when the player is in the air and moving horizontally at the same time
        float move = Input.GetAxis("Horizontal"); //player is moving
        myAnim.SetFloat("speed", Mathf.Abs(move)); //the player is moving at a pace
        myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y); //velocity of the player increases as the player is walking along
        if(move>0&&!facingRight){ //if the player is moving left the flip method is called
            flip();
        } else if(move<0&&facingRight){ //if the player is moving right the flip method is called
            flip();
        }
    }

    void flip(){ //if the player swaps direction, then the following will occur
        facingRight=!facingRight; 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}