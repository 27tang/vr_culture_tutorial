using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	public GameObject wall;
	private Vector3 maxPosition;
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
		goTime = true;
	}
	public void deactivate(){
		wall.SetActive (false);
	}

	void oppress(){
		if (this.transform.position.z > maxPosition.z) {
			Debug.Log ("should be moving");
			Debug.Log (this.transform.position.z);
			Debug.Log (maxPosition.z);
			wall.transform.Translate (Vector3.back * Time.deltaTime);
		}
	}
	// Update is called once per frame
	void Update () {
		if (goTime) {
			//Debug.Log ("should be moving");
			oppress ();
			Debug.Log ("afterOppress");
		} 
	}
}
