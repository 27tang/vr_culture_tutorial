using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Player : MonoBehaviour {

	public GameObject welcomeText;
	public GameObject secondText;

	// Use this for initialization
	void Start () {
		//welcomeText.SetActive (false);
		secondText.SetActive(false);

		welcomeText.GetComponent<UIFader> ().FadeIn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void displayWelcomeText(){

	}
}
