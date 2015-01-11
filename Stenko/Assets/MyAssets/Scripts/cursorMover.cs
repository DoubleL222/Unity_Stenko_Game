using UnityEngine;
using System.Collections;

public class cursorMover : MonoBehaviour {
	public float minX;
	public float minY;
	public float maxX;
	public float maxY;
	private float currX;
	private float currY;
	private float newX;
	private float newY;
	private Vector3 prevPosition;
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currX = rigidbody.transform.position.x;
		currY = rigidbody.transform.position.y;
		newX = Mathf.Clamp (currX, -10, 10);
		newY = Mathf.Clamp(currY,-10, 10);
		rigidbody.transform.position = new Vector3(newX,newY,0);
	}
}
