using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handle the rotation and rotation lock of the cannon object and the cannon's muzzle and neck
//splits the rotation between the 2 axis and objects
//horizontal horation around the Y-axis rotates the entire cannon object
//vertical rotation around the X-axis rotates the neck and muzzle of the cannon

public class RotationManager : MonoBehaviour {
    //because of how the object was made, the cannon starts off at 75 degrees of X rotation
    private float currentXRotation = 75.0f;
    //make sure you get these in the correct order! Otherwise you will have unexpected behavior (or none at all).
    //also make sure your current rotation is within this range so it does not snap to the min or max angle upon user input
    private float minXAimAngle = 45; // ex: 45
    private float maxXAimAngle = 90; //ex: 90

    private float currentYRotation = 0.9f;
    private float minYAimAngle = -45; // ex: 45
    private float maxYAimAngle = 45; //ex: 90

    private CannonBehaviorSolution cannon;

    [SerializeField]
    private CannonBodyBehavior cannonBody;

    void Start(){
    	cannon = GetComponent<CannonBehaviorSolution>();
    }

    void Update(){
        //seperate function for handling the input
        //clears up update
    	handleArrowInput();
    }

    private void handleArrowInput(){
        //if the user is inputing up or down
        //no sense checking if there is no input
    	if(Input.GetAxis ("Vertical")!=0){
            //-Input leads to up aiming up and down aiming down
    		currentXRotation += -Input.GetAxis ("Vertical") * 2;
            //clamp values between the predefined min and max angles
			currentXRotation = Mathf.Clamp(currentXRotation, minXAimAngle, maxXAimAngle);
            //set rotation (transform.eulerAngles) to the current X rotation and preserve the other 2 rotations
    		cannonBody.transform.eulerAngles = new Vector3(currentXRotation,cannonBody.transform.eulerAngles.y, cannonBody.transform.eulerAngles.z);
    	}
        //same for left and right but this affects the whole cannon object
    	if(Input.GetAxis ("Horizontal")!=0){
    		currentYRotation += Input.GetAxis ("Horizontal") * 2;
			currentYRotation = Mathf.Clamp(currentYRotation, minYAimAngle, maxYAimAngle);
    		cannon.transform.eulerAngles = new Vector3(cannon.transform.eulerAngles.x,currentYRotation,cannon.transform.eulerAngles.z);
    	}
    }
}