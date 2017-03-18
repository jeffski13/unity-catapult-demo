using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehavior : MonoBehaviour {
    //true if on last frame, fire button was down
    private bool fire1Down = false;
    //number of frames fire button was held
    private int framesHeld = 0;
    //was missle fired?
    private bool mizzilesFired = false;

    [SerializeField] private CrashCam cam;
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space)) {
            //make sure missile has not been launched 
            if (!mizzilesFired) {
                framesHeld++;
                if(framesHeld%50 == 0) {
                    cam.AddNextPowerBlock();
                }
            }

        }
        else {
            if(framesHeld > 0 && !mizzilesFired) {
                //FIRE ZE MISSILES!
                mizzilesFired = true;
                FireUpAndOver(framesHeld);
            }
        }

    }

    private void FireUpAndOver() {
        GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * 200);
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void FireUpAndOver(int power) {
        GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * power);
        GetComponent<Rigidbody>().useGravity = true;
    }

    
}
