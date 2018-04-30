using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour {

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
					this.GetComponent<AudioSource> ().Play ();
					other.GetComponentInChildren<Animator> ().SetBool ("awake", true);
				}
			} else {
				if(other.GetComponent<PlayerManager> ().color == outer.GetComponent<RaySection>().colornumber){
					this.GetComponent<AudioSource> ().Play ();
					other.GetComponentInChildren<Animator> ().SetBool ("awake", true);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Player")){
			if (other.GetComponent<PlayerManager> ().outer != null) {
				if (other.GetComponent<PlayerManager> ().color == mid.GetComponent<RaySection> ().colornumber) {
					other.GetComponentInChildren<Animator> ().SetBool ("awake", true);
				} else {
					other.transform.SetParent(null);
				}
			} else {
				if (other.GetComponent<PlayerManager> ().color == outer.GetComponent<RaySection> ().colornumber) {
					other.GetComponentInChildren<Animator> ().SetBool ("awake", true);
				} else {
					other.transform.SetParent(null);
				}
			}
		}
	}
}
