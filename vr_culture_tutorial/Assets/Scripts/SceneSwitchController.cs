using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchController : MonoBehaviour {

	public GameObject welcomeText;
	public GameObject secondText;
	public GameObject thirdText; //narrator tip 1(personal space)
	public GameObject boxEvent;
	public GameObject wall;
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
				gameStage++;
				break;
			case 3: //box spitting a butterflyball
				releaseButterflies();		
				gameStage++;
				break;
			case 4:
				boxEvent.GetComponent<BoxController> ().deactivate ();
				secondText.SetActive (false);
				thirdText.SetActive (true);
				break;
			case 5:
				thirdText.SetActive (false);
				wall.GetComponent<WallController> ().activate ();
				gameStage++;
				break;
			case 6:
				gameStage++;
				break;
			}
			Debug.Log("gameStage:");
			Debug.Log (gameStage);
		}

	}

	void releaseButterflies(){
		if (!alreadyReleased) {
			boxEvent.GetComponent<BoxController> ().releaseButts ();
			alreadyReleased = true;
		}
	}
}
