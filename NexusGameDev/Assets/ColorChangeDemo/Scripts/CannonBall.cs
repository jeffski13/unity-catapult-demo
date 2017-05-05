using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FireCannon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FireCannon(){
        this.GetComponent<Rigidbody>().AddForce(new Vector3(-250,250,0));
    }

}
