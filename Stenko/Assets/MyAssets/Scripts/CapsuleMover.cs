using UnityEngine;
using System.Collections;

public class CapsuleMover : MonoBehaviour {
	public Transform kursor;
	private Vector3 prevPosition;
	private Vector3 diference;
	public float movementY=0;
	public float movementX=0;
	// Use this for initialization
	void Awake () {
		prevPosition = kursor.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		diference = kursor.position - prevPosition;
		prevPosition = kursor.position;
		diference.y = diference.y * movementY;
		diference.x = diference.x * movementX;
	//	movementY in movementX sta koeficienta raztega premika kurzorja
		rigidbody.transform.position = rigidbody.position +diference;




	}
}
