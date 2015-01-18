using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayPoints : MonoBehaviour {

	public Text displayText;

	private int points;
	// Use this for initialization
	void Start () {
		points = PlayerPrefs.GetInt ("Level 1 returns");
		if (points > 0 && points <= 10) {
						displayText.text = "Preostale točke: "+points; 
				} else if (points == 0) {
						displayText.text = "Zmanjkalo je točk!"; 
						PlayerPrefs.SetInt ("Level 1 returns", 10);
				} else {
					PlayerPrefs.SetInt ("Level 1 returns", 10);
					points = PlayerPrefs.GetInt ("Level 1 returns");
					displayText.text = "Preostale točke: "+points; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
