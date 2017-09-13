using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	[SerializeField] GameObject scoreBoxCanvas;
	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject howToPlay;

	public void startNewGame(){
		SceneManager.LoadScene (0);
		//GameManager.Instance.SetActiveGameCanvas (true);
	}

	/*public void howToPlay(){
		//gameObject
	}*/
}
