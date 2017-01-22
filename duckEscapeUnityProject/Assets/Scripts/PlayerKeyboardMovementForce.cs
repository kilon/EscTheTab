using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMovementForce : MonoBehaviour {
	Vector3 forceForward;
	public Rigidbody rb;
	public float forceMultiplier;
	//public float torqueMultiplier;
	public float rotationMultiplier;
	// Use this for initialization
	void Start () {
		forceForward = transform.right*forceMultiplier;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddRelativeForce (forceForward);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb.AddRelativeForce (-forceForward);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//rb.AddRelativeTorque (transform.up * (-torqueMultiplier));
			transform.RotateAround (transform.position,Vector3.up,-Time.deltaTime*rotationMultiplier);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//rb.AddRelativeTorque (transform.up * (torqueMultiplier));
			transform.RotateAround (transform.position,Vector3.up,Time.deltaTime*rotationMultiplier);
		}
	}
}
