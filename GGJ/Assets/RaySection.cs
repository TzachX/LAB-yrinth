using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colors{
	red = 2,
	blue = 3,
	yellow = 4,
	purple = 5,
	orange = 6,
	green = 7
}

public class RaySection : MonoBehaviour {

	[SerializeField] private Sprite[] colorsprites;
	[SerializeField] private SpriteRenderer sr;
	public int colornumber;


	// Use this for initialization
	void Start () {
	}

	public void SetPartColor(int colID)
	{
		sr.sprite = colorsprites [colID - 2];
		colornumber = colID;
	}
}
