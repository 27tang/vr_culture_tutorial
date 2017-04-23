using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

	public GameObject box;
	public GameObject butterflies;
	Animator anim;

	void Awake() {
		anim = GetComponentInChildren <Animator> ();
	}
	// Use this for initialization
	void Start () {
		butterflies.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activate(){
		box.SetActive (true);

	}
	public void deactivate(){
		box.SetActive (false);
		butterflies.SetActive (false);
	}

	public void releaseButts(){
		
		anim.SetBool ("ShouldOpen", true);
		StartCoroutine(delay());
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (1f);
		butterflies.SetActive (true);
	}

	public void killButterflies(){
		butterflies.SetActive (false);
	}

}
