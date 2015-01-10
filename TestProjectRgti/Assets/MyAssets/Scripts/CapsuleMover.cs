using UnityEngine;
using System.Collections;

public class CapsuleMover : MonoBehaviour {
	public Transform kursor;
	private Vector3 prevPosition;
	private Vector3 diference;
	public float movementY;
	public float movementX;
	// Use this for initialization
	void Awake () {
		prevPosition = kursor.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		diference = kursor.position - prevPosition;
		prevPosition = kursor.position;
	//	Debug.Log ("kursor:" + kursor.position);
		//Debug.Log ("prev position:" + prevPosition);
		diference.y = diference.y * movementY;
		diference.x = diference.x * movementX;
	//	Debug.Log ("the difference is:"+diference);
		rigidbody.transform.position = rigidbody.position +diference;




	}
}
