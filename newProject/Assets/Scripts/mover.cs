using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public int orientation;
	public float speed;
	// Use this for initialization
	void Start () {
		Vector3 vecX = new Vector3 (orientation, 0, 0);
		rigidbody.velocity = vecX * speed;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
