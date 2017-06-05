using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBallBehavior : MonoBehaviour {
    //true if on last frame, fire button was down
    private bool fire1Down = false;
    //number of frames fire button was held
    private int framesHeld = 0;
    private const float FRAMES_HELD_MAX = 400;
    //was missle fired?
    private bool mizzilesFired = false;
    
    private Vector3 missleStartPos;

    [SerializeField]
    private List<Boxy> boxys;

    [SerializeField]
    private CrashCam cam;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private Image powerbar;

    [SerializeField]
    private DualAxisRotationController rotationController;

    void Start() {
        missleStartPos = this.transform.position;

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            //make sure missile has not been launched 
            if(!mizzilesFired && framesHeld < FRAMES_HELD_MAX) {
                framesHeld += 10;
                powerText.text = "Power: " + framesHeld;
                powerbar.fillAmount = (float)framesHeld / FRAMES_HELD_MAX;
            }

        }
        else {
            if(framesHeld > 0 && !mizzilesFired) {
                //FIRE ZE MISSILES!
                mizzilesFired = true;
                FireUpAndOver(rotationController.GetVectorForward(), framesHeld);
            }
        }

        if(Input.GetKey(KeyCode.R)) {
            Init();
        }
    }

    private void FireUpAndOver(Vector3 launchAngle, int power) {
        GetComponent<Rigidbody>().AddForce((launchAngle * 5) * power);
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void Init(){
        //reset missle position
        this.transform.position = missleStartPos;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //clear out power ui
        powerText.text = "Power: 0";
        powerbar.fillAmount = 0;

        //reset state for firing
        mizzilesFired = false;
        framesHeld = 0;

        foreach(Boxy box in boxys){
            box.Reset();
        }
    }

    
}
