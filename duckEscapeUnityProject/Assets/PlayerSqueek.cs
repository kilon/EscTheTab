using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSqueek : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip squeek;
	// Use this for initialization
	float timer;
	float nextDur;
	float pitch;
	void Start () {
		timer = 0.0f;
		nextDur = Random.Range (3.0f, 6.0f);
		pitch = Random.Range (0.9f, 1.4f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > nextDur) {
			timer = 0.0f;
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
			audioSource.pitch = pitch;
			audioSource.PlayOneShot (squeek);
			nextDur = Random.Range (3.0f, 6.0f);
			pitch = Random.Range (0.8f, 1.2f);
		}
	}
}
