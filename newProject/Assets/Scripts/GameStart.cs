using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	public void ClickedStart () {
		Application.LoadLevel("level1");
	}

}
