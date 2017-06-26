using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBallBehavior : MonoBehaviour {
    
    private Vector3 missleStartPos;

    void Start() {
        missleStartPos = this.transform.position;
        GetComponent<Rigidbody>().useGravity = false;

        //Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireUpAndOver(Vector3 launchAngle, int power) {
        print("Firing");
        print(launchAngle);
        print(power);
        GetComponent<Rigidbody>().AddForce((launchAngle * 10) * power);
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void Init(){
        //reset missle position
        this.transform.position = missleStartPos;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    
}
