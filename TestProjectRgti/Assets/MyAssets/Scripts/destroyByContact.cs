using UnityEngine;
using System.Collections;

public class destroyByContact : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		Destroy (gameObject);
		}
	void OnTriggerStay(Collider other){
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
