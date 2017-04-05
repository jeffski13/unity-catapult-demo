using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControlX : MonoBehaviour {

    // the initial & current rotation of the cannonBody
    private float currentRotationX = -15;

    private float maxAimAngle = -5; //ex: 45
    private float minAimAngle = -55; // ex: 90

    void Start() {
        currentRotationX = transform.localEulerAngles.x;
        Debug.Log(currentRotationX);
    }

    public Vector3 GetFacingAngleVector() {
        Vector3 launchAngle = transform.rotation * Vector3.forward;
        return launchAngle;
    }
    
    public void HandleVerticalRotation(float verticalInput) {
        currentRotationX += verticalInput * 2;
        Debug.Log(currentRotationX);
        currentRotationX = Mathf.Clamp(currentRotationX, minAimAngle, maxAimAngle);
        Debug.Log(currentRotationX);

        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

}
