using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed = 0.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		if (h != 0 || v != 0) {
						rigidbody.AddForce (new Vector3(h,0,v)*speed);
				}
	}
}
