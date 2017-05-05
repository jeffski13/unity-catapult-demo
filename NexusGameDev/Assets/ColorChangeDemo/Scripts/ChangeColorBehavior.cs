using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBehavior : MonoBehaviour {
    public int frameSwitch = 50;

    int frameCount = 0;
    string[] colorStrArr = {"badstring", "#111", "#222", "#333", "#444", "#555", "#666", "#777", "#888", "#999", "#aaa",
        "#0f00", "#0f01", "#0f02", "#0f03", "#0f04", "#0f05", "#0f06", "#0f07", "#0f08", "#0f09", "#0f0a", };
	int arrIndex;
    
	void Update () {
        //confusing way to switch colors every X frames.
        frameCount++;
        if(frameCount % frameSwitch == 0){
            arrIndex++;
            if(arrIndex == colorStrArr.Length) {
                arrIndex = 0;
            }
            ChangeMaterialColor(colorStrArr[arrIndex]);
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
        material.SetColor("_Color", albedoColor);
    }
}
