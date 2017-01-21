using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMovementForce : MonoBehaviour {
	Vector3 forceForward;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		forceForward = transform.right*5.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddRelativeForce (forceForward);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.RotateAround (transform.position,Vector3.up,-Time.deltaTime*90.0f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.RotateAround (transform.position,Vector3.up,Time.deltaTime*90.0f);
		}
	}
}
