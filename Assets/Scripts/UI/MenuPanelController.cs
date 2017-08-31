using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelController : MonoBehaviour {
	public void showMainMenu(){
		gameObject.SetActive (true);
	}

	public void hideMainMenu(){
		gameObject.SetActive (false);
	}

}
