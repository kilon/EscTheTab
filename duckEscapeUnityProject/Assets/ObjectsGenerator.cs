using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour {
	public int numCrabs;
	public int numSharks;
	public int numBalls;
	public GameObject crabPrefab;
	public GameObject sharkPrefab;
	public GameObject ballPrefab;
	GameObject crabInstance;
	GameObject sharkInstance;
	GameObject ballInstance;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numCrabs; i++) {
			float x = Random.Range (0.65f,11.2f);
			float y = -0.5f;
			float z = Random.Range (0.2f, 4.9f);
			Vector3 pos = new Vector3 (x, y, z);
			float angle = Random.Range (0.0f, 360f);
			Quaternion rot = Quaternion.Euler (0.0f,angle,0.0f);
			crabInstance = Instantiate (crabPrefab, transform.position, rot);
			crabInstance.transform.parent = transform;
		}

		for (int i = 0; i < numSharks; i++) {
			float x = Random.Range (0.65f,11.2f);
			float y = -0.5f;
			float z = Random.Range (0.2f, 4.9f);
			Vector3 pos = new Vector3 (x, y, z);
			float angle = Random.Range (0.0f, 360f);
			Quaternion rot = Quaternion.Euler (0.0f,angle,0.0f);
			sharkInstance = Instantiate (sharkPrefab, transform.position, rot);
			sharkInstance.transform.parent = transform;
		}

		for (int i = 0; i < numBalls; i++) {
			float x = Random.Range (0.65f,11.2f);
			float y = -0.5f;
			float z = Random.Range (0.2f, 4.9f);
			Vector3 pos = new Vector3 (x, y, z);
			float angle = Random.Range (0.0f, 360f);
			Quaternion rot = Quaternion.Euler (0.0f,angle,0.0f);
			ballInstance = Instantiate (ballPrefab, transform.position, rot);
			ballInstance.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
