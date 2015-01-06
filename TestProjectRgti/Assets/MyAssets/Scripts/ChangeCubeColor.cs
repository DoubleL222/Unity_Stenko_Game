using UnityEngine;
using System.Collections;

public class ChangeCubeColor : MonoBehaviour {

	GameObject startCube;
	GameObject exitCube;
	GameObject handLeft;
	GameObject handRight;

	public void Clean() {
		startCube.renderer.material.color = new Color(1,1,1,1);
		exitCube.renderer.material.color = new Color(1,1,1,1);
	}

	public void ChangeProgress(float c, float x, float y) {
		if (x < 0.3f && y < 0.4f) {
			startCube.renderer.material.color = new Color(1-c,1,1-c,1);
		}
		else if (x > 0.7f && y < 0.4f) {
			exitCube.renderer.material.color = new Color(1,1-c,1-c,1);
		}
	}

	public void Changed(float x, float y) {
		if (x < 0.3f && y < 0.4f) {
			startCube.rigidbody.freezeRotation = false;
			handLeft.SetActive(false);
			StartCoroutine(WaitAndLoadLevel(2.0F));
		}
		else if (x > 0.7f && y < 0.4f) {
			exitCube.rigidbody.freezeRotation = false;
			handRight.SetActive(false);
			StartCoroutine(WaitAndLoadLevel(2.0F));
		}
	}

	IEnumerator WaitAndLoadLevel(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
	}

	// Use this for initialization
	void Start () {
		startCube = GameObject.Find("CubeLeft");
		exitCube = GameObject.Find("CubeRight");
		handLeft = GameObject.Find("HandCursor1");
		handRight = GameObject.Find("HandCursor2");

	}

}
