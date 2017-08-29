using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public Text livesText;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		//livesText.
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
