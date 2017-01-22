using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaterController : MonoBehaviour {
	GameObject waterObject;
	List<GameObject> waveSources; //all of the wave sources....
	public Material waterMaterial;
	// Use this for initialization
	void Start () {
		createWaterObject ();
		waveSources = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		updateWaterMesh ();
	}

	void updateWaterMesh(){
		waveSources.Clear();
		waveSources = GameObject.FindGameObjectsWithTag ("wavesource").ToList ();
		Mesh waterMesh = waterObject.GetComponent<MeshFilter> ().mesh;
		Vector3[] points = waterMesh.vertices;
		for (int i = 0; i < points.Length; i++) {
			float x = points [i].x;
			float y = calculateWaterY(points[i]);
			float z = points [i].z;
			Vector3 p = new Vector3 (x,y,z);
			points [i] = p;
		}
		waterMesh.vertices = points;
		waterMesh.RecalculateNormals();
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
			y += 3.0f * Mathf.Sin ((dist) * 6.0f - time * 12.0f) / (dist*12.0f + 4.0f);
		}
		return y;
	}

	private void createWaterObject()
	{
		waterObject = new GameObject("_WaterObject");
		waterObject.transform.parent = transform;
		Mesh newMesh = new Mesh();
		waterObject.AddComponent<MeshFilter>();
		waterObject.AddComponent<MeshRenderer>();
		List<Vector3> verticeList = new List<Vector3>();
		List<Vector2> uvList = new List<Vector2>();
		List<int> triList = new List<int>();
		int width = 130;
		int length = 65;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < length; j++)
			{
				float x = i/8.0f;
				float y = j/8.0f;
				verticeList.Add(new Vector3(x, 0f, y));
				uvList.Add(new Vector2(x, y));
				//Skip if a new square on the plane hasn't been formed
				if (x == 0 || y == 0)
					continue;
				//Adds the index of the three vertices in order to make up each of the two tris
				triList.Add(length * i +j); //Top right
				triList.Add(length * i + j - 1); //Bottom right
				triList.Add(length * (i - 1) + j - 1); //Bottom left - First triangle
				triList.Add(length * (i - 1) + j - 1); //Bottom left 
				triList.Add(length * (i- 1) + j); //Top left
				triList.Add(length * i + j); //Top right - Second triangle
			}
		}
		newMesh.vertices = verticeList.ToArray();
		newMesh.uv = uvList.ToArray();
		newMesh.triangles = triList.ToArray();
		newMesh.RecalculateNormals();
		waterObject.GetComponent<MeshFilter>().mesh = newMesh;
		waterObject.GetComponent<Renderer>().material = waterMaterial;;
		//return waterObject;
	}
}
