using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.z < 0.0f) || (transform.position.x > 16.9f)) {
			Application.LoadLevel ("EndScene");
		}
	}
}
