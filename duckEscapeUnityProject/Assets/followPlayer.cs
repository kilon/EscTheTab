using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	GameObject player;
	Vector3 myPosFlat;
	Vector3 playerPosFlat;
	Vector3 towardsPlayer;
	public Rigidbody rb;
	public float followForceMultiplier;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("_Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myPosFlat = new Vector3 (transform.position.x, 0.0f, transform.position.z);
		playerPosFlat = new Vector3 (player.transform.position.x,0.0f,player.transform.position.z);
		towardsPlayer = playerPosFlat - myPosFlat;
		towardsPlayer.Normalize();
		towardsPlayer *= followForceMultiplier;
		rb.AddForce (towardsPlayer);
	}
}
