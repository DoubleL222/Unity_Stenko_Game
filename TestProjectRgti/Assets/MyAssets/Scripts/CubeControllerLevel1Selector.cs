using UnityEngine;
using System.Collections;

public class CubeControllerLevel1Selector : MonoBehaviour {
	GameObject[,] sides = new GameObject[4,6];
	int[] enumColors = {0,1,2,3,4,5};

	Color[]  shuffleSimple ( Color[] arr  ){
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
		Color[] colorArray = { Color.red, Color.green, Color.yellow, Color.blue, 
			Color.white, new Color32(238,130,238,255)};
		Color[] colorArrayFake = new Color[6];
		for (int j = 1; j < 5; j++) { 
			for (int i = 1; i < 7; i++) {
				sides [j-1,i - 1] = GameObject.Find ("Side" + j + i);
			}
		}
		for (int i = 0; i < 6; i++) {
			enumColors[i] = PlayerPrefs.GetInt("Color" + i);
			Debug.Log (enumColors[i]);
		}
		int correctCube = PlayerPrefs.GetInt ("Correct cube");
		Debug.Log (correctCube);
		for (int i = 0; i < 4; i++) {
			if(correctCube == (i + 1)) {
				for(int j = 0; j < 6; j++) {
					sides[i,j].renderer.material.color = colorArray[enumColors[j]];
				}
			}
			else {
				colorArrayFake = shuffleSimple(colorArray);
				for(int j = 0; j < 6; j++) {
					sides[i,j].renderer.material.color = colorArrayFake[enumColors[j]];
				}
			}
		}
			
	}

}
