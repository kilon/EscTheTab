using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterForce : MonoBehaviour {
	public float waterForceMultiplier;
	public WaterController water;
	public Rigidbody rb;
	Vector3 myPos;
	Vector3 waterPos;
	Vector3 waterForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myPos = new Vector3( transform.position.x, transform.position.y - 0.3f, transform.position.z);
		float waterPosY = 0.0f; //  water.calculateWaterY (myPos);
		waterPos = new Vector3 (myPos.x, waterPosY, myPos.z);
		waterForce = waterPos - myPos;
		waterForce *= waterForceMultiplier;
		rb.AddForce (waterForce);
	}
}
