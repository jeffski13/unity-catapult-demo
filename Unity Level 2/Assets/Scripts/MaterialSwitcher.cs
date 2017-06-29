using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//apply to objects with Boxy script
//manages changing the objects material when hit
public class MaterialSwitcher : MonoBehaviour {
    //my start material reference
    public Material defaultMaterial;
    //material to change to when hit
    public Material hitMaterial;
    //the renderer component
    private Renderer render;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
	}

    public void Reset(){
        changeMaterial("Default");
    }

    //function to switch materials based on the state given
    private void changeMaterial(string state){
        
        if(state == "Hit"){
            Material[] materials = render.materials;
            materials[0] = hitMaterial;
            render.materials = materials;

        }else if(state == "Default"){
            Material[] materials = render.materials;
            materials[0] = defaultMaterial;
            render.materials = materials;
        }

    }

    //check when something collides with me if it is something I care about
    //right now a box should only care if a cannon ball hits it
    void OnCollisionEnter(Collision collision){
        //check by tag; could also check by class but useful for cases where 2 objects 
        //may have the same class but serve different roles in the scene
        if(collision.gameObject.tag == "CannonBall"){
            //check to see if the cannon ball is "active" or a "live" shot and should be used to calculate points
            //a "dead" cannon ball shoudln't increase points 
            //(not to be confused with destroyed cannon ball which no longer exists)
            if(collision.gameObject.GetComponent<Projectile>().getIsActive()){
                changeMaterial("Hit");
            }
        }
    }
}