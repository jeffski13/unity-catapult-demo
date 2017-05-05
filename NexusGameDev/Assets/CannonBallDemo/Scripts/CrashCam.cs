using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCam : MonoBehaviour {

    private Vector3 initialPowerBlockPosition = new Vector3(-0.5f, -0.25f, 1);
    private Vector3 powerBlockPositionDelta = new Vector3(0.25f, 0, 0);
    private int numBlocks = 0;
    [SerializeField]
    private GameObject powerBlockPrefab;

    public void AddNextPowerBlock() {
        GameObject nextPowerBlock = Instantiate(powerBlockPrefab);
        nextPowerBlock.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        nextPowerBlock.GetComponent<Transform>().localPosition = initialPowerBlockPosition + powerBlockPositionDelta * numBlocks;

        numBlocks++;
    }
}
