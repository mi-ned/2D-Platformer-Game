using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=g-ku3I-Ts7Y&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=26
//This class makes sure that the snowball shoots at different places

public class sporeController : MonoBehaviour
{
    public float sporeSpeedHigh; //highest spore speed
    public float sporeSpeedLow; //lowest spore speed
    Rigidbody2D sporeRB; //rigidbody is activated to make sure that the spore is there
    public float sporeAngle; //spore angle is set
    public float sporeTorqueAngle; //torque angle is the rotation of the snowball once fired

    void Start() {
        sporeRB = GetComponent<Rigidbody2D>(); //rigidbody is activated
        //the spore angle is randomised between lowest and highest range of speed
        //the force and torque gets added leading up to an 'out of control' cannon
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle,sporeAngle),Random.Range(sporeSpeedLow,sporeSpeedHigh)),ForceMode2D.Impulse);
        sporeRB.AddTorque(Random.Range(-sporeTorqueAngle, sporeTorqueAngle));
    }
}