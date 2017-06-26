using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//apply to objects with Boxy script
//manages changing the objects material when hit
public class MaterialSwitcher : MonoBehaviour {
	private Vector3 startPos;
    public Material defaultMaterial;
    public Material hitMaterial;
    private Renderer render;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
	}

    public void Reset(){
        changeMaterial("Default");
    }

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

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "CannonBall"){
            changeMaterial("Hit");
        }
    }
}