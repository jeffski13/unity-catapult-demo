using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attached to the canon game object
//acts as the game manager

public class CannonBehaviorSolution : MonoBehaviour {

    //true if on last frame, fire button was down
    private bool fire1Down = false;
    //number of frames fire button was held
    private int framesHeld = 0;
    private const float FRAMES_HELD_MAX = 400;
    //was missle fired?
    private bool mizzilesFired = false;

    [SerializeField]
    //private List<Boxy> boxys;
    private List<BoxySolution> boxys;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private Image powerbar;

    //reference to the actual body of the canon (the part that rotates up and down)
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
                
                //get the vector of the muzzle of the cannon from the cannonBody object
                Vector3 newAngle = cannonBody.getCannonAim();

                //grab the SpawnProjectile Component and call FireUpAndOver
                //the code actually could live here if needed
                //the SpawnProjectile needs a spawn point reference and the prefab to instantiate
                GetComponent<SpawnProjectile>().FireUpAndOver(newAngle,framesHeld);

                //begin the cooldown sequence
                StartCoroutine(powerDown());
            }
        }

        if(Input.GetKey(KeyCode.R)) {
            ////Init();
            //reset all the boxes
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
        foreach(BoxySolution box in boxys){
            box.Reset();
        }

    }

    //cooldown coroutine
    //after firing, the coroutine handles subtracting power and updating UI
    //there is a wait for seconds in the while loop to slow down the effect over several frames
    //the cooldown can be sped up by either increasing the subtractPower or by decreasing the wait time
    IEnumerator powerDown() {
        int subtractPower = 4;
        while (framesHeld > 0){
            framesHeld -= subtractPower;
            powerbar.fillAmount = (float)framesHeld / FRAMES_HELD_MAX;
            powerText.text="Power: "+framesHeld;
            yield return new WaitForSeconds(.025f);
        }
        Init();
    }
}