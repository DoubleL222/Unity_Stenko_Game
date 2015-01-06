using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void Selected (int a) {
		//if( a == 1) {
		Debug.Log (a);
		Application.LoadLevel ("ParticleMan");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
