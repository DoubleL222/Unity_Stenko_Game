using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	private int orientation;
	public float speed;
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("roBot");
		CharacterMove playerScript = player.GetComponent<CharacterMove>();
		orientation = playerScript.smer;
		Vector3 vecX = new Vector3 (orientation, 0, 0);
		rigidbody.velocity = vecX * speed;

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
