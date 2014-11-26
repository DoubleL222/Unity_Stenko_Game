using UnityEngine;
using System.Collections;

public class PlatformCamera : MonoBehaviour {
	public Transform Hero;

	void  Update (){
		transform.position = new Vector3(Hero.position.x, Hero.position.y + 2, transform.position.z);
	}
	
}