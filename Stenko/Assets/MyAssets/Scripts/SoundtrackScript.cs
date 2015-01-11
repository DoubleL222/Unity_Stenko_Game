using UnityEngine;
using System.Collections;

public class SoundtrackScript : MonoBehaviour {
	private static SoundtrackScript instance = null;
	public static SoundtrackScript Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	void Update() {
		if (Application.loadedLevelName == "MathNinja") 
			gameObject.audio.mute = true;
		else
			gameObject.audio.mute = false;
	}

}
