using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationManager : MonoBehaviour {

    private float currentVerticalRotation = 75.0f;
    //make sure you get these in the correct order! Otherwise you will have unexpected behavior (or none at all).
    //also make sure your current rotation is within this range so it does not snap to the min or max angle upon user input
    private float minVertAimAngle = 45; // ex: 45
    private float maxVertAimAngle = 90; //ex: 90

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
    	handleArrowInput();
    }

    private void handleArrowInput(){
    	if(Input.GetAxis ("Vertical")!=0){
    		currentVerticalRotation += -Input.GetAxis ("Vertical") * 2;
			currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, minVertAimAngle, maxVertAimAngle);
    		cannonBody.transform.eulerAngles = new Vector3(currentVerticalRotation,cannonBody.transform.eulerAngles.y, cannonBody.transform.eulerAngles.z);
    	}
    	if(Input.GetAxis ("Horizontal")!=0){
            print("Rotate");
    		//using forces which moves the cannon and the cannon ball through Physics!
    		////cannon.GetComponent<Rigidbody>().AddForce(cannon.transform.right * Input.GetAxis ("Horizontal") * 10);

    		currentYRotation += Input.GetAxis ("Horizontal") * 2;
			currentYRotation = Mathf.Clamp(currentYRotation, minYAimAngle, maxYAimAngle);
    		cannon.transform.eulerAngles = new Vector3(cannon.transform.eulerAngles.x,currentYRotation,cannon.transform.eulerAngles.z);
    	}
    }
}