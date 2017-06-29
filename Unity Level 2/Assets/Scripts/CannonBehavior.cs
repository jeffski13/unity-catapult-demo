using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attached to the canon game object
//acts as the game manager

public class CannonBehavior : MonoBehaviour {

    //true if on last frame, fire button was down
    private bool fire1Down = false;
    //number of frames fire button was held
    private int framesHeld = 0;
    private const float FRAMES_HELD_MAX = 400;
    //was missle fired?
    private bool mizzilesFired = false;

    [SerializeField]
    //private List<Boxy> boxys;
    private List<Boxy> boxys;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private Image powerbar;

    //reference to the cannon ball
    [SerializeField]
    private CannonBallBehavior cannonBall;

    //referecne to the cannon body (the neck and muzzle of the cannon)
    [SerializeField]
    private CannonBodyBehavior cannonBody;

    void Start() {

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
                Vector3 newAngle = cannonBody.getCannonAim();
                cannonBall.FireUpAndOver(newAngle,framesHeld);

            }
        }

        if(Input.GetKey(KeyCode.R)) {
            Init();
            //reset cannon ball
            cannonBall.Init();
            //reset boxes
            resetBoxes();
        }
    }

    private void Init(){

        //clear out power ui
        powerText.text = "Power: 0";
        powerbar.fillAmount = 0;

        //reset state for firing
        mizzilesFired = false;
        framesHeld = 0;

    }

    private void resetBoxes(){
        //call each box's reset method
        foreach(Boxy box in boxys){
            box.Reset();
        }

    }
}