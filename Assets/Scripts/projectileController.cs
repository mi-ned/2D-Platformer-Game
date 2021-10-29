using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=pWVR3g2PWow&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=11
//This class controlls any projectiles (other than the bullet from the final level)
public class projectileController : MonoBehaviour
{
    public float projectileSpeed; //speed of the projectile
    Rigidbody2D myRB; //rigidbody is set
    
    void Awake() { //the enemy that fires the projectile will always be on alert
        myRB = GetComponent<Rigidbody2D>(); //the rigidbody component will be called.
        myRB.AddForce(new Vector2(-1,0)*projectileSpeed, ForceMode2D.Impulse); //the bullet will only shoot left (as opposed to all around)
    }

    public void removeForce(){
        myRB.velocity=new Vector2(0,0); //once the projectile makes the hit, the force of the projectile is removed
    }
}