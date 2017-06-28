using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxySolution : MonoBehaviour {
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
	}

    public void Reset(){
        this.transform.position = startPos;
        this.transform.eulerAngles = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<MaterialSwitcher>().Reset();
    }

}
