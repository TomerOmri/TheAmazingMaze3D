using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlayController : MonoBehaviour {

	public void showHowToPlay(){
		gameObject.SetActive (true);
	}

	public void hideHowToPlay(){
		gameObject.SetActive (false);
	}
}
