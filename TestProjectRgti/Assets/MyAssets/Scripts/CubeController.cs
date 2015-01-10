using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	GameObject[] sides = new GameObject[6];
	int[] enumColors = {0,1,2,3,4,5};

	Color[]  shuffle ( Color[] arr  ){
		for (int i = 5; i > 0; i--) {
			int r = Random.Range(0,i);

			int temp = enumColors[i];
			enumColors[i] = enumColors[r];
			enumColors[i] = temp;

			Color tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
		return arr;
	}

	// Use this for initialization
	void Start () {
		// Only for testing
		// PlayerPrefs.SetInt ("Colors set up", 0);
		                
		for (int i = 1; i < 7; i++) {
			sides[i-1] = GameObject.Find("Side" + i);
		}
		Color[] colorArray = { Color.red, Color.green, Color.yellow, Color.blue, 
			Color.white, new Color32(238,130,238,255)};
		if (PlayerPrefs.GetInt ("Colors set up") == 0) { //shufflej, shrani podatke v playerprefs, spremeni colors set up, določi correct cube
			colorArray = shuffle (colorArray);
			for (int i = 0; i < 6; i++) {
					sides [i].renderer.material.color = colorArray [i];
					PlayerPrefs.SetInt ("Color" + i, enumColors [i]);
			}

			PlayerPrefs.SetInt ("Colors set up", 1);
			PlayerPrefs.SetInt ("Correct cube", Random.Range (1, 4));

		} else {
			for (int i = 0; i < 6; i++){
				enumColors[i] = PlayerPrefs.GetInt ("Color" + i);
				sides [i].renderer.material.color = colorArray [enumColors[i]];
			}
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
