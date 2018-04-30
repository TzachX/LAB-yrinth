using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        
    }


    // Update is called once per frame
    void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Player") {
			print ("touch");
			other.transform.SetParent(null);
		}
	}
	void OnCollisionStay2D(Collision2D other) {
		if (other.collider.tag == "Player") {
			print ("touch");
			other.transform.SetParent(null);
		}
	}
}
