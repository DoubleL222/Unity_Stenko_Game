using UnityEngine;
using System.Collections;

public class ChangeCubeColorLevelSelect : MonoBehaviour {
	//string level = "FirstScreen";

	public GameObject Click;
	GameObject cube1;
	GameObject cube2;
	GameObject cube3;
	GameObject cube4;
	GameObject handLeft;
	GameObject handRight;

	public void Clean() {
		cube1.renderer.material.color = new Color(1,1,1,1);
		cube2.renderer.material.color = new Color(1,1,1,1);
		cube3.renderer.material.color = new Color(1,1,1,1);
		cube4.renderer.material.color = new Color(1,1,1,1);
	}

	public void ChangeProgress(float c, float x, float y) {
		if (x <= 0.2f && y <= 0.4f ) {
			cube1.renderer.material.color = new Color(1,1,1-c,1);
		}
		else if (x >= 0.3f && y <= 0.7f && x <= 0.5f) {
			cube2.renderer.material.color = new Color(1-c,1,1-c,1);
		}
		else if (x > 0.55f && y <= 0.4f && x <= 0.7f) {
			cube3.renderer.material.color = new Color(1-c,1-c,1,1);
		}
		else if (x >= 0.8f && y <= 0.5f) {
			cube4.renderer.material.color = new Color(1,1-c,1-c,1);
		}
	}

	public void Changed(float x, float y) {
		if (x < 0.2f && y < 0.4f ) {
			cube1.rigidbody.freezeRotation = false;
			cube1.rigidbody.constraints = RigidbodyConstraints.None;
			handLeft.SetActive(false);
			//level = "test";
			StartCoroutine(WaitAndLoadLevel1(1.0F));
		}
		else if (x > 0.3f && y < 0.7f && x < 0.45f) {
			cube2.rigidbody.freezeRotation = false;
			cube2.rigidbody.constraints = RigidbodyConstraints.None;
			handRight.SetActive(false);
			//level = "test2";
			StartCoroutine(WaitAndLoadLevel3(1.0F));
		}
		else if (x > 0.55f && y < 0.4f && x < 0.7f) {
			cube3.rigidbody.freezeRotation = false;
			cube3.rigidbody.constraints = RigidbodyConstraints.None;
			handRight.SetActive(false);
			//level = "test3";
			StartCoroutine(WaitAndLoadLevel1(1.0F));
		}
		else if (x > 0.8f && y < 0.5f) {
			cube4.rigidbody.freezeRotation = false;
			cube4.rigidbody.constraints = RigidbodyConstraints.None;
			handRight.SetActive(false);
			//level = "test4";
			StartCoroutine(WaitAndLoadLevel2(1.0F));
		}
	}

	IEnumerator WaitAndLoadLevel1(float waitTime) {
		Click.audio.Play ();
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("Level1"); // load scene
	}

	IEnumerator WaitAndLoadLevel3(float waitTime) {
		Click.audio.Play ();
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("MathNinja"); // load scene
	}

	IEnumerator WaitAndLoadLevel2 (float waitTime) {
		Click.audio.Play ();
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("FirstScreen"); // load scene
	}

	// Use this for initialization
	void Start () {
		cube1 = GameObject.Find("Cube1");
		cube2 = GameObject.Find("Cube2");
		cube3 = GameObject.Find("Cube3");
		cube4 = GameObject.Find("Cube4");
		handLeft = GameObject.Find("HandCursor1");
		handRight = GameObject.Find("HandCursor2");

		PlayerPrefs.SetInt ("Colors set up", 0);

	}

}
