using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script applied to the cannon ball prefab
//basic projectile class
//cares about managing whether or not it is "active" or "alive"
//for point calculation and when to destroy itself

//side notes for thought: we could eliminate the isActive bool and keep track of its status
//through a tag: activeCannonBall vs deadCannonBall
//then we don't have to check in the box script if the cannon ball is "alive"; we know via the tags
//downside is we don't want bajillions of tags floating around... or do we? Is that a bad thing aside from
//logistics and keeping up with those? #Documentation

public class Projectile : MonoBehaviour {

	//life span of this projectile in seconds
	private int maxLife = 10;
	//should this add points when it hits something
	private bool isActive = true;

	// Use this for initialization
	void Start () {
		StartCoroutine("calculateDeath");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void destroySelf(){
		Destroy(gameObject);
	}

	public bool getIsActive(){
		return isActive;
	}

	public void makeInactive(){
		isActive = false;
	}

	IEnumerator calculateDeath() {
        yield return new WaitForSeconds(maxLife);
        destroySelf();
    }

    //if it hits the ground it is considered a "dead" cannon ball and should not add points
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Floor"){
            makeInactive();
        }
    }
}
