using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBodyBehavior : MonoBehaviour {
	
	void Start() {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 getCannonAim(){
    	return transform.rotation * Vector3.up;
    }
}