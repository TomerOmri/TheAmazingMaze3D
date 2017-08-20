using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public float MoveSpeed = 5f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25f;
	public Vector3 MoveVector{ set;get;}
	public VirtualJoystick Joystick;
	private Rigidbody BallRigidBody;

	// Use this for initialization
	void Start () {
		BallRigidBody = gameObject.AddComponent<Rigidbody> ();
		BallRigidBody.maxAngularVelocity = terminalRotationSpeed;
		BallRigidBody.drag = drag;
	}

	// Update is called once per frame
	void Update () {
//		MoveVector = PoolInput();
		Move ();

	}

	private void Move(){
		BallRigidBody.AddForce ((MoveVector * MoveSpeed));
	}

//	private Vector3 PoolInput(){
//		Vector3 dir = Vector3.zero;
//		dir.x = Joystick.Horizonal ();
//		dir.y = Joystick.Vertical ();
//
//		if (dir.magnitude > 1) {
//			dir.Normalize ();
//		}
//
//		Vector3 rotatedDir = camTransform.TransformDirection (dir);
//		rotatedDir = new Vector3 (rotatedDir.x, 0, rotatedDir.z);
//		rotatedDir = rotatedDir.normalized * dir.magnitude;
//
//	}
}
