using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjector : MonoBehaviour {
    
    [SerializeField] private GameObject arrowPrefab;
    //have arrows and just throw their position back?
	private GameObject arrow;

	// Update is called once per frame
	void Update () {
	    if(arrow == null) {
            arrow = Instantiate(arrowPrefab);
        }
        else{
            arrow.transform.position += new Vector3(0, 0.02f, 0);

            if(arrow.transform.position.y > 2) {
                Destroy(arrow);
            }
        }
	}
}
