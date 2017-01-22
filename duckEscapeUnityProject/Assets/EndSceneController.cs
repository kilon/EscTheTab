using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour {
	float initialTime;
	float currentTime;
	float duration;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.time;
		duration = Time.time - initialTime;
		if (duration > 3.0f) {
			Application.LoadLevel ("MenuScene");
		}

	}
}
