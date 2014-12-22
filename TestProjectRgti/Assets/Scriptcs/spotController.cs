using UnityEngine;
using System.Collections;

public class spotController : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		gameObject.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			gameObject.light.enabled= !gameObject.light.enabled;
		}
	}
}
