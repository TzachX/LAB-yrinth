using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int color;
	Color vcolor;
	public bool onGoal;
	public GameObject outer;
	float move;
	bool facingright;
	Animator anim;
	public string chgcolor{ get; set;}
	SpriteRenderer[] sr;
	AudioSource ados;
	//int colorIchangedto

	// Use this for initialization
	void Start () {
		ados = GetComponent<AudioSource> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		switch (color) {
		case (int)colors.red:
			vcolor = Color.red;
			break;
		case (int)colors.blue:
			vcolor = Color.blue;
			break;
		case (int)colors.yellow:
			vcolor = Color.yellow;
			break;
		case (int)colors.purple:
			vcolor = new Color(0.75f,0f,1.3f);
			break;
		case (int)colors.orange:
			vcolor = new Color(2.55f,1.65f,0);
			break;
		case (int)colors.green:
			vcolor = Color.green;
			break;
		}
		foreach (SpriteRenderer s in sr) {
			if (!(s.gameObject.CompareTag ("Eyes") || s.gameObject.CompareTag("Antena"))){
				s.material.color = vcolor;
			}
		}
		anim = GetComponentInChildren<Animator> ();
		if (transform.localScale.x > 0) {
			facingright = true;
		} else {
			facingright = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("SideCollider"))
		{
			if (!anim.GetBool ("ready")) {
				anim.SetBool ("awake", false);
			}
		}
		if(other.CompareTag("RayCenter"))
		{
				anim.SetBool ("ready", false);
		}
		if(other.CompareTag("Goal"))
		{
			onGoal = false;
			other.transform.Find ("ptcl").gameObject.SetActive (false);
			anim.SetBool ("onGoal",false);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") != 0 && anim.GetBool ("ready")) {
			ados.Play ();
		} else {
			ados.Stop ();
		}
			
		if (Input.GetKeyDown (KeyCode.Space)) {
			print (onGoal);
		}
		if (anim.GetBool ("ready")) {
			anim.SetFloat ("speed", Input.GetAxis ("Horizontal"));
			Flip (Input.GetAxis ("Horizontal"));
		}
	}

	void Flip(float hor)
	{
		if (hor > 0 && !facingright || hor < 0 && facingright) {
			facingright = !facingright;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Goal"))
		{
			other.transform.Find ("ptcl").gameObject.SetActive (true);
			other.GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Goal"))
		{
			onGoal = true;
			anim.SetBool ("onGoal",true);
		}
	}
	/*public void ColorEffect(string col){
		if (outer != null) {
			switch (col) {
			case("Red"):
				{
					
				}
			}
		}
	}*/
}
