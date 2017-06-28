using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	//life span of this projectile in seconds
	private int maxLife = 10;
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

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Floor"){
            makeInactive();
        }
    }
}
