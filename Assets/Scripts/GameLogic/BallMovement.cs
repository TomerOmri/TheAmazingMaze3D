using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
	[SerializeField] float speed = 6f;
	private Rigidbody rb;
	public int livesOfPlayer = 3;
	public Text livesText;

	void Start(){
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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "base") {
			rb.velocity = new Vector3 (0, 0, 0);
			rb.isKinematic = true;
			transform.position = GameObject.Find ("ResponePoint").transform.position;
			rb.isKinematic = false;
		} else if (other.gameObject.name == "colider") {
			rb.velocity = new Vector3 (0, 0, 0);
			rb.isKinematic = true;
			transform.position = GameObject.Find ("Respone2").transform.position;
			rb.isKinematic = false;
		} else if (other.gameObject.name == "FinishHole") {
			//need to print You win and the Time and fallTimes
		}

	}
}
