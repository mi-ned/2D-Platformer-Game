using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=pWVR3g2PWow&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=11
//Similar to  the 1st playerController script (with some differences of course), 
//I've made a seperate script from the original one, since this one enables the player to shoot, wheras the original doesn't shoot
//This means that the enemy will not be squashed like on the previous levels.
public class playerController2 : MonoBehaviour
{
    public float maxSpeed;
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    Rigidbody2D myRB;
    Animator myAnim;
    public bool facingRight;
    public Transform gunTip; //this is where the bullets will come out, since the player will now be holding a gun
    public GameObject bullet; //spawns a bullet
    float fireRate = 0.5f; //fire rate is set to 0.5. anything slower or higher will affect the gun
    float nextFire = 0f; //set to 0, the nextFire will be added to prevent the bullets from fireing all at once
    public AudioClip gunSound;
    
    void Start()
    {  
       myRB = GetComponent<Rigidbody2D>();
       myAnim = GetComponent<Animator>();
       facingRight = true; 
    }

    void Update(){
        if(grounded && Input.GetAxis("Jump")>0){
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0,jumpHeight));
        }
        
       if(Input.GetAxisRaw("Fire1")>0) fireGun(); //if the player presses the click button, the weapon will fire (by calling the fireGun method)
    }

    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded",grounded);
        myAnim.SetFloat("verticalSpeed",myRB.velocity.y);
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);
        if(move>0&&!facingRight){
            flip();
        } else if(move<0&&facingRight){
            flip();
        }
    }

    void flip(){
        facingRight=!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireGun(){
        if(Time.time > nextFire){ //prevents the gun from firing multiple rounds
            nextFire = Time.time+fireRate; //nextFire gets changed, hence preventing the gun from firing multiple rounds
            
            if(facingRight) { //if the player is facing right, then...
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,0)));
            AudioSource.PlayClipAtPoint(gunSound,transform.position);
            }
            else if(!facingRight) { //if the player is facing left, then...
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}