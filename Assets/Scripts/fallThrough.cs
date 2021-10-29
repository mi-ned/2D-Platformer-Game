using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=8EavQJPvz3w&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=28
//This class prevents other objects (namely shootable) from getting destroyed when they touch the cleaner

public class fallThrough : MonoBehaviour
{
    void Start() {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shootable"),LayerMask.NameToLayer("Shootable"));

    }
}