using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	GameObject player;
	Vector3 playerPos;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("_Player");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		playerPos.y = 0.0f;
		transform.LookAt (playerPos);
	}
}
