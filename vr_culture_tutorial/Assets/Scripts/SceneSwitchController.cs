﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchController : MonoBehaviour {

	public GameObject welcomeText;
	public GameObject secondText;
	public GameObject boxEvent;
	public GameObject wall;
	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private GameObject collidingObject; 


	private int gameStage = 2;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();

	}

	void Start() {
		//welcomeText.SetActive (false);
		secondText.SetActive(false);
		boxEvent.GetComponent<BoxController> ().deactivate ();

		//welcomeText.GetComponent<UIFader> ().FadeIn ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Controller.GetHairTriggerDown()) {
			switch (gameStage)
			{
				
			case 2: //box level
				welcomeText.SetActive (false);
				secondText.SetActive (true);
				boxEvent.GetComponent<BoxController> ().activate ();
				gameStage++;
				break;
			case 3: //box spitting a butterflyball
				secondText.SetActive (false);
				boxEvent.GetComponent<BoxController> ().releaseButts ();
				gameStage++;
				break;
			case 4:
				boxEvent.GetComponent<BoxController> ().deactivate ();
				wall.GetComponent<WallController> ().activate ();
				Debug.Log ("in case 4");
				gameStage++;
				break;
			case 5:
				gameStage++;
				break;
			}
		}



	
	}
}
