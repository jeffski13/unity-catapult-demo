using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlY : MonoBehaviour {

    // the initial & current rotation of the cannonBody
    private float currentRotationY = 0;

    private float maxAimAngle = 45; //ex: 45
    private float minAimAngle = -45; // ex: 90
    
    void Start() {
        currentRotationY = transform.localEulerAngles.x;
    }

    public Vector3 getFacingAngleVector() {
        Vector3 launchAngle = transform.rotation * Vector3.forward;
        return launchAngle;
    }
    
    public void HandleHorizontalRotation(float horizontalInput) {
        currentRotationY += horizontalInput * 2;
        currentRotationY = Mathf.Clamp(currentRotationY, minAimAngle, maxAimAngle);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentRotationY, transform.localEulerAngles.z);
    }

}
