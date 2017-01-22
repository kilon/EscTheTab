using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyForceApplier : MonoBehaviour {
	public float buoyancyForceMultiplier;
	WaterController water;
	public Rigidbody rb;
	Vector3 myPos;
	Vector3 waterPos;
	Vector3 waterForce;
	// Use this for initialization
	void Start () {
		water = GameObject.Find ("_Water").GetComponent<WaterController> () as WaterController;
	}

	// Update is called once per frame
	void FixedUpdate () {
		myPos = new Vector3( transform.position.x, transform.position.y - 0.3f, transform.position.z);
		float waterPosY = 0.0f; //  water.calculateWaterY (myPos);
		waterPos = new Vector3 (myPos.x, waterPosY, myPos.z);
		waterForce = waterPos - myPos;
		waterForce.Normalize ();
		waterForce *= buoyancyForceMultiplier;
		if ((transform.position.z > 0.0f)&&(transform.position.x < 16.9f)) {
			rb.AddForce (waterForce);
		}
	}
}
