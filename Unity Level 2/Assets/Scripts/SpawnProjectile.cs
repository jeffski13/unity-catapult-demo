using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectile : MonoBehaviour {
    
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject cannonBall;

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireUpAndOver(Vector3 launchAngle, int power) {
        print("Firing");
        GameObject newProjectile = Instantiate(cannonBall,spawnPoint.position,Quaternion.identity);
        newProjectile.GetComponent<Rigidbody>().AddForce((launchAngle * 10) * power);
        newProjectile.GetComponent<Rigidbody>().useGravity = true;
    }

    
}