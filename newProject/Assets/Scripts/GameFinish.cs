using UnityEngine;
using System.Collections;

public class GameFinish : MonoBehaviour {

	void  OnGUI (){
		GUI.contentColor = Color.black;
		GUI.Label ( new Rect(Screen.width/2 - 45, Screen.height/2, 200, 25), "Dobil si zaklad!");
		if (GUI.Button( new Rect(Screen.width/2 - 60, Screen.height/2 + 20 ,120,25),"Ponovno igraj!")) {
			Application.LoadLevel("level1");
		}
	}
}
