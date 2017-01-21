using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : MonoBehaviour {
	public GameObject waterParticlePrefab;
	GameObject waterParticleInstance;
	Vector3[,] waterPoints; //2d array holding the waterpoints
	int waterPointsSizeX;
	int waterPointsSizeY;
	List<GameObject> waterParticles; 
	List<GameObject> waveSources; //all of the wave sources....

	// Use this for initialization
	void Start () {
		initializeWaterPoints();
		initializeWaterParticles ();
		waveSources = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		float time = Time.time;
		waveSources.Clear();
		//ySum.Clear ();
		waveSources = GameObject.FindGameObjectsWithTag ("wavesource").ToList ();
		for (int i = 0; i < waterParticles.Count; i++) {
			float y = calculateWaterY(waterParticles[i].transform.position);
			Vector3 p = new Vector3 (waterParticles [i].transform.position.x, y, waterParticles [i].transform.position.z);
			waterParticles[i].transform.position = p;
		}
	}

	public float calculateWaterY(Vector3 point){
		float time = Time.time;
		float x = point.x;
		float z = point.z;
		float y = 0;
		for (int i = 0; i < waveSources.Count; i++) {
			Vector2 p1 = new Vector2 (x,z);
			Vector2 p2 = new Vector2 (waveSources[i].transform.position.x, waveSources[i].transform.position.z);
			float dist = Vector2.Distance (p1,p2);
			y += Mathf.Sin (dist*8 - time*6.0f) / (dist*3.0f + 8.0f);
		}
		return y;
	}


	void initializeWaterPoints(){
		waterPointsSizeX = 100;	//array X dimension
		waterPointsSizeY = 100;	//array Y dimension
		waterPoints = new Vector3[waterPointsSizeX,waterPointsSizeY]; //initialize 2d array
		for (int i = 0; i < waterPointsSizeX; i++) {
			for (int j = 0; j < waterPointsSizeY; j++) {
				float x = (float)i / 10.0f;
				float z = (float)j / 10.0f;
				float y = 0.0f;
				waterPoints [i,j] = new Vector3 (x, y, z);
			}
		}
	}

	void initializeWaterParticles(){
		waterParticles = new List<GameObject> ();
		for (int i = 0; i < waterPointsSizeX; i++) {
			for (int j = 0; j < waterPointsSizeY; j++) {
				Vector3 pos = waterPoints [i,j];
				waterParticleInstance = Instantiate (waterParticlePrefab, pos, Quaternion.identity);
				waterParticles.Add (waterParticleInstance);
			}
		}
	}

}
