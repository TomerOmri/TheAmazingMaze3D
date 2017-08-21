using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	private float Direction = 1f;
	[SerializeField] float Speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	void move(){

		Vector3 movemen = new Vector3 (0f, 0f, Direction);
		GetComponent<Rigidbody> ().AddForce (movemen * Speed);

	}
}
