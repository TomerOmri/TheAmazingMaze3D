using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	public void showLives(){
		gameObject.SetActive (true);
	}

	public void hideLives(){
		gameObject.SetActive (false);
	}
}
