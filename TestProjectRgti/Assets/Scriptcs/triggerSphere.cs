using UnityEngine;
using System.Collections;

public class triggerSphere : MonoBehaviour {

	public GameObject luc;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
						luc.light.enabled = true;
				}
	}
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
						luc.light.enabled = false;
				}
	}
}
