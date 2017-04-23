using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	public GameObject wall;
	private Vector3 maxPosition;
	public GameObject wallText;
	public GameObject eugene;
	private bool eugeneSpoke = false;

	bool goTime = false;
	// Use this for initialization
	void Start () {
		maxPosition = this.transform.position;
		maxPosition.z -= 5;
		Debug.Log ("maxpos's z");
		Debug.Log (maxPosition.z);
	}

	public void activate(){
		Debug.Log ("activate in wallcontroller");
		wall.SetActive (true);
		wallText.SetActive (true);
		goTime = true;
	}
	public void deactivate(){
		Debug.Log ("we are in deactivate");
		wall.SetActive (false);
		wallText.SetActive (false);
	}

	void oppress(){
		if (this.transform.position.z > maxPosition.z) {
			Debug.Log ("should be moving");
			Debug.Log (this.transform.position.z);
			Debug.Log (maxPosition.z);
			wall.transform.Translate (Vector3.back * Time.deltaTime / 2);
			wallText.transform.Translate (Vector3.back * Time.deltaTime / 2);

		} else if (!eugeneSpoke) {
			playEugene ();
			eugeneSpoke = true;
		}
	}

	void playEugene(){
		AudioSource a = eugene.GetComponent<AudioSource> ();
		a.Play();
	}

	// Update is called once per frame
	void Update () {
		if (goTime) {
			//Debug.Log ("should be moving");
			oppress ();
			//Debug.Log ("afterOppress");
		} 
	}
}
