using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference:  https://www.youtube.com/watch?v=g-ku3I-Ts7Y&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=26
//This class determines at what time a projectile lives. If a projectiles lives its past time, the object will be destroyed

public class DestroyMe : MonoBehaviour
{
    public float aliveTime;

    void Awake() {
        Destroy(gameObject, aliveTime);
    }
}