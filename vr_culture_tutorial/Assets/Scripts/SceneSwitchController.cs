using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchController : MonoBehaviour {

	public GameObject welcomeText;
	public GameObject secondText;
	public GameObject thirdText; //narrator tip 1(personal space)
	public GameObject boxEvent;
	public GameObject wall;
	public GameObject fourthText;
	private bool alreadyReleased;
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
		thirdText.SetActive (false);
		boxEvent.GetComponent<BoxController> ().deactivate ();
		wall.GetComponent<WallController> ().deactivate ();
		fourthText.SetActive (false);

		//welcomeText.GetComponent<UIFader> ().FadeIn ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Controller.GetHairTriggerDown()) {
			switch (gameStage)
			{
				
			case 2: //box level
				welcomeText.SetActive (false);
				secondText.SetActive (true);//approach and click
				boxEvent.GetComponent<BoxController> ().activate ();
				break;
			case 3: //box spitting a butterflyball
				releaseButterflies();		
				break;
			case 4:
				boxEvent.GetComponent<BoxController> ().deactivate ();
				secondText.SetActive (false);
				thirdText.SetActive (true);
				break;
			case 5:
				thirdText.SetActive (false);
				wall.GetComponent<WallController> ().activate ();
				break;
			case 6:
				Debug.Log ("in case 6");
				wall.GetComponent<WallController> ().deactivate ();
				fourthText.SetActive (true);
				break;
			case 7:
				fourthText.SetActive (false);
				break;
			}
			Debug.Log("gameStage:");
			Debug.Log (gameStage);
			gameStage++;
		}

	}

	void releaseButterflies(){
		if (!alreadyReleased) {
			boxEvent.GetComponent<BoxController> ().releaseButts ();
			alreadyReleased = true;
		}
	}
}
