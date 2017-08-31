using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
	[SerializeField] float speed = 10f;
	private Rigidbody rb;
	public int livesOfPlayer = 3;
	public Text livesText;

	void Start(){
		Lives ();
		rb = GetComponent<Rigidbody> ();
	}
	// Each physics step..
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void Lives(){
		livesText.text = "Lives:" + livesOfPlayer.ToString ();
	}

	void OnTriggerEnter(Collider other){
	
		//livesText.text = "You fall!";
		//livesOfPlayer--;
		//Lives ();
		//DontDestroyOnLoad (this);
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene("MainMenu");
	}
}
