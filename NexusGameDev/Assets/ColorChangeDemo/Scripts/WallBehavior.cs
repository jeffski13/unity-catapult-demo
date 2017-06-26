using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour {

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.GetComponent<CannonBall>()) {
            this.ChangeMaterialColor("#0f0");
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.GetComponent<CannonBall>()) {
            this.ChangeMaterialColor("#00f5");
        }
    }

    //parse hex color string to change material
    private void ChangeMaterialColor(string albColorStr){
        Material material = GetComponent<Renderer>().material;
        //red is the default
        Color albedoColor;
        if(!ColorUtility.TryParseHtmlString(albColorStr, out albedoColor)) {
            //NOTE: returns false if couldnt parse string
            albedoColor = Color.red;
        }
        //material.SetColor("_Color", albedoColor);
        material.color = albedoColor;
    }
}
