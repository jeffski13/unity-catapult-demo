using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualAxisRotationController : MonoBehaviour {

    [SerializeField]
    RotationControlY rotationControlY;
    [SerializeField]
    RotationControlX rotationControlX;

    public bool inverted = true;
    public GameObject reticalMesh;

    void Update () {
        int invertedCalc = 1;
        if (!inverted) {
            invertedCalc = -1;
        }

        if (Input.GetAxis("Vertical") != 0) {
            rotationControlX.HandleVerticalRotation(invertedCalc * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0) {
            rotationControlY.HandleHorizontalRotation(invertedCalc * -Input.GetAxis("Horizontal"));
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            reticalMesh.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            reticalMesh.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            reticalMesh.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            reticalMesh.SetActive(true);
        }
        else {
            reticalMesh.SetActive(false);
        }

    }

    public Vector3 GetVectorForward() {
        return rotationControlX.GetFacingAngleVector();
    }

}
