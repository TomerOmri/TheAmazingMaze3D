using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	private int curr = 0;
	public Transform[] target;

	[SerializeField] float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance( transform.position , target[curr].position)>0.15f) {
			transform.position = Vector3.Lerp (transform.position, target[curr].position,  Time.deltaTime);
			//GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			curr = (curr + 1) % target.Length;
		}
	}
}
