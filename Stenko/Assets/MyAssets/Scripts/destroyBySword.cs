using UnityEngine;
using System.Collections;

public class destroyBySword : MonoBehaviour {

	private gameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <gameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	
	}
	void OnTriggerEnter (Collider other)
	{
 		Destroy (other.gameObject);
	//	Debug.Log ("enter");
		gameController.AddScore (1);
		audio.Play ();
	}
	void OnTriggerStay (Collider other)
	{
		//Destroy (other.gameObject);
	//	Debug.Log ("stay");
	}
	void OnTriggerExit (Collider other)
	{
	//	Debug.Log ("exit");
	}
	// Use this for initialization
/*	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
