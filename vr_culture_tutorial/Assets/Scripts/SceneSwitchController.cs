using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private GameObject collidingObject; 

	private GameObject cube; 
	private GameObject ball; 



	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();

	}

	void Start()
	{
		cube =  GameObject.FindWithTag ("Cube");
		ball =  GameObject.FindWithTag ("Ball");

		ball.SetActive (false);




	}

	// Update is called once per frame
	void Update () {
		
		if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) {
			if (cube.activeSelf) {
				//deactivate ball and activate cube
				cube.SetActive (false);
				ball.SetActive (true);
				Debug.Log ("cubed");
			} else {
				//deactivate cube and activate ball
				cube.SetActive (true);
				ball.SetActive (false);
				Debug.Log ("not");
			}
		}



	
	}
}
