using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour {

	public Transform center;
	float deg = -0.5f;
	private Vector3 v;
	Vector3 dir;
	private GameObject player{ get; set;}
	[SerializeField] private GameObject mid;
	[SerializeField] private GameObject outer;
	public bool stopped = false;

	// Use this for initialization
	void Start () {
		v = transform.position - center.position;
		dir = v;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!stopped) {
			v = Quaternion.AngleAxis (deg * Input.GetAxis ("Horizontal"), Vector3.forward) * v;
			transform.position = center.position + v;
			dir = transform.position - center.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			if (player != null) {
				if (player.GetComponent<PlayerManager> ().chgcolor != null) {
					//outer.GetComponent<RaySection> ().SetPartColor (player.GetComponent<PlayerManager> ().chgcolor);
				}
			}
		}
	}

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && transform.name != "RightCollider" && transform.name != "LeftCollider"){
			print ("ok");
			if (other.GetComponent<PlayerManager> ().outer != null) {
				if (other.GetComponent<PlayerManager> ().color.Equals("Blue")) {
					other.transform.SetParent (transform);
				}
			} else {
				if(other.GetComponent<PlayerManager> ().color.Equals("Purple")){
					other.transform.SetParent (transform);
				}
			}
		}
	}*/


}
