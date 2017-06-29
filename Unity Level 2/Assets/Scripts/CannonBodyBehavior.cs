using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//basicaly all this does is get the vector the cannon muzzle is facing towards
// I feel like I had more planned for this... oh well.

public class CannonBodyBehavior : MonoBehaviour {
	
	void Start() {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 getCannonAim(){
    	return transform.rotation * Vector3.up;
        //side note; it has to be Vector3.up bcause of how the cannon was modeled
        //the muzzel at 0 rotation face straight up, so up is the correct vector to find
        //where it pointing
    }
}