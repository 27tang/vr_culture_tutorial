﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripController : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private GameObject collidingObject; 
	private GameObject objectInHand;
	private GameObject cube;
	private GameObject ball; 

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

//	void Start()
//	{
		
//	}

	private void SetCollidingObject(Collider col)
	{
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{ return; }
		collidingObject = col.gameObject;
	}


	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}
		
	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}
		
	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}

	private void GrabObject()
	{
		
		objectInHand = collidingObject;
		collidingObject = null;
	
		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
	}


	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		
		if (GetComponent<FixedJoint>())
		{

			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());

			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}

		objectInHand = null;
	}

	// Update is called once per frame
	void Update () {
		
		if (Controller.GetHairTriggerDown())
		{
			Debug.Log ("down");
			if (collidingObject)
			{
				GrabObject();
			}
		}


		if (Controller.GetHairTriggerUp())
		{
			Debug.Log ("up");
			if (objectInHand)
			{
				ReleaseObject();
			}
		}
	}
}