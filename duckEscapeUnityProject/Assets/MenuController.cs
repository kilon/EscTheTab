using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playGame(){
		Application.LoadLevel ("PlayScene");
	}

	public void goToCredits(){
		Application.LoadLevel ("CreditsScene");
	}

	public void quitGame(){
		Application.Quit ();
	}
}
