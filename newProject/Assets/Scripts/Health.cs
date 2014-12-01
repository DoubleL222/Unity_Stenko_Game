using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public float maxHealth;
	public Slider slider;
	public float currHealth = 1.0f;
	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
	}
	
	void OnTriggerEnter(Collider other){
		currHealth = currHealth - 0.05f * maxHealth;
		slider.value = currHealth / maxHealth * 100.0f;


		if (currHealth <= 0) {
			Application.LoadLevel("gameFinish");
				}
	}
}
