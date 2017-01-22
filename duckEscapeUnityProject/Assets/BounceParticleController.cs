using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceParticleController : MonoBehaviour {
	public AudioClip bounceClip;
	public AudioSource audioSource;
	float pitch;
	// Use this for initialization
	void Start () {
		pitch = Random.Range (0.8f, 1.2f);
		audioSource.pitch = pitch;
		audioSource.PlayOneShot (bounceClip);
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			Destroy (this.gameObject);
		}
	}
}
