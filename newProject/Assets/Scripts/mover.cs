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
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			return;		
		}
		if (other.tag == "Environment" || other.tag== "robotShot") {
			collider.isTrigger=false;
			Transform child = transform.FindChild("VFX");
			float x= child.renderer.bounds.size.x;
			transform.position=transform.position+new Vector3(-x/2.0f, 0, 0);
			rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			return;
		}
		Destroy (gameObject);
	}
	// Update is called once per frame

}
