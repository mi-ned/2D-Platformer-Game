using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=xSZRYGZ6TqA&list=PL2cNFQAw_ndyKRiobQ2WqVBBBSbAYBobf&index=13
//This class enables the camera to follow the main charachter around

public class cameraFollow2Dplatformer : MonoBehaviour
{
    public Transform target; //Sets the target (i.e. player)
    public float smoothing; //Changes the FPS ratings somewhat, as well as how smooth the camera is moving along
    Vector3 offset; //how far the camera is from the game itself
    float lowY; //the Y position (up or down)

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - target.position; //offset is set through the transform position (where the player is) and target position (where the charachter is)
        lowY = transform.position.y; //gets the y axis.
    }

    void Update(){
               //Pause Game
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
            //Quit Game
            if (Input.GetKey("escape"))
             Application.Quit();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(target != null){ //if the target is alive then the following will happen... (Without this if statement, exception errors will arise)
            Vector3 targetCamPos = target.position + offset; //the camera will set to the player
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing*Time.deltaTime); //wherever the player is (up, down, left or right), the camera will always follow him
        }
    }
}
