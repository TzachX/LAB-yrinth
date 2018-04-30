using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCollider : MonoBehaviour {

	[SerializeField] private GameObject mid;
	[SerializeField] private GameObject outer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")){
			if (other.GetComponent<PlayerManager> ().outer != null) {
				if (other.GetComponent<PlayerManager> ().color == mid.GetComponent<RaySection>().colornumber) {
					other.GetComponentInChildren<Animator> ().SetBool ("ready", true);
					other.transform.SetParent (transform);
				}
			} else {
				if(other.GetComponent<PlayerManager> ().color == outer.GetComponent<RaySection>().colornumber){
					other.GetComponentInChildren<Animator> ().SetBool ("ready", true);
					other.transform.SetParent (transform);
				}
			}
		}
	}
		
}
