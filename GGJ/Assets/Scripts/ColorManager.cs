using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour {

	[SerializeField] private GameObject mid;
	[SerializeField] private GameObject outer;
	[SerializeField] private GameObject ray;
	[SerializeField] private GameObject[] robots;
	[SerializeField] private GameObject winmsg;
	bool won = true;
	Scene scene;


	// Use this for initialization
	void Start () {
			mid.GetComponent<RaySection> ().SetPartColor ((int)colors.blue);
			outer.GetComponent<RaySection> ().SetPartColor ((int)colors.blue + (int)colors.red);
			scene = SceneManager.GetActiveScene ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
		if (scene.name != "Demo") {
			print (ray.transform.eulerAngles.z);
			if ((ray.transform.eulerAngles.z > 96 && ray.transform.eulerAngles.z < 222)) {
				mid.GetComponent<RaySection> ().SetPartColor ((int)colors.blue);
				outer.GetComponent<RaySection> ().SetPartColor ((int)colors.blue + (int)colors.yellow);
			} else {
				mid.GetComponent<RaySection> ().SetPartColor ((int)colors.red);
				outer.GetComponent<RaySection> ().SetPartColor ((int)colors.red + (int)colors.yellow);
			}
		}
		won = true;
		for (int i = 0; i < robots.Length; i++) {
			if (robots[i].GetComponent<PlayerManager> ().onGoal == false) {
				won = false;
			}
		}
		if (won) {
			winmsg.SetActive (true);
			ray.GetComponent<Ray> ().stopped = true;
		}
	}

	public void LoadScene1()
	{
			SceneManager.LoadScene("Demo");
	}

	public void LoadScene2()
	{
		SceneManager.LoadScene("Demo 1");
	}
}
