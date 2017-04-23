using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchController : MonoBehaviour {

	public GameObject welcomeText;
	public GameObject secondText;
	public GameObject boxEvent;
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
				
			case 2:
				welcomeText.SetActive (false);
				secondText.SetActive (true);
				gameStage++;
				break;
			case 3: //box spitting a butterflyball
				secondText.SetActive (false);
				boxEvent.GetComponent<BoxController> ().activate ();
				gameStage++;
				break;
			case 4:
				boxEvent.GetComponent<BoxController> ().releaseButts ();
				gameStage++;
				break;
			case 5:
				boxEvent.GetComponent<BoxController> ().deactivate ();
				gameStage++;
				break;
			}
		}



	
	}
}
