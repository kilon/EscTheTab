using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterForce : MonoBehaviour {
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
		myPos = transform.position;
		float waterPosY = water.calculateWaterY (myPos);
		waterPos = new Vector3 (myPos.x, waterPosY, myPos.z);
		waterForce = waterPos - myPos;
		waterForce *= 100.0f;
		rb.AddForce (waterForce);
	}
}
