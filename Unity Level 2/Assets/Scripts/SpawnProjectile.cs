using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//just a componetized script to handle instantiating the cannon ball prefab and firing it
//can be migrated over to CannonBehavior script
//is attached to the cannon object (with the CannonBehavior script)
//the cannon should be in charge of firing the cannon ball
//the cannon ball should only care it it is "alive" for point calculation and when to destroy itself
//also if applied to the cannon ball, gets odd because all spawned cannonballs would be listening for input to fire themselves

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