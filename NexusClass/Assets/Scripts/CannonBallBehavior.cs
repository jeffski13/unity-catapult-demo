using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBallBehavior : MonoBehaviour {
    //true if on last frame, fire button was down
    private bool fire1Down = false;
    //number of frames fire button was held
    private int framesHeld = 0;
    //was missle fired?
    private bool mizzilesFired = false;

    [SerializeField]
    private CrashCam cam;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private DualAxisRotationController rotationController;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            //make sure missile has not been launched 
            if (!mizzilesFired && framesHeld < 500) {
                framesHeld++;
                powerText.text = "Power: " + framesHeld;
            }
        }
        else {
            if(framesHeld > 0 && !mizzilesFired) {
                //FIRE ZE MISSILES!
                mizzilesFired = true;
                FireUpAndOver(rotationController.GetVectorForward(), framesHeld);
            }
        }
    }

    private void FireUpAndOver(Vector3 launchAngle, int power) {
        GetComponent<Rigidbody>().AddForce((launchAngle * 5) * power);
        GetComponent<Rigidbody>().useGravity = true;
    }

    
}
