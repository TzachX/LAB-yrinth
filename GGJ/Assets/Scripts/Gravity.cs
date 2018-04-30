using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public Transform center;
    public float deg = -1f;
    private Vector3 v;
    Vector3 dir;

    // Use this for initialization
    void Start () {
        v = transform.position - center.position;
        dir = v;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        v = Quaternion.AngleAxis(deg * Input.GetAxis("Horizontal"), Vector3.forward) * v;
        transform.position = center.position + v;
        dir = transform.position - center.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}
