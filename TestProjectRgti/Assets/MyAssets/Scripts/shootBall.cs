using UnityEngine;
using System.Collections;

public class shootBall : MonoBehaviour {

	public float fireRate=2;
	public float TfireRate=0.2f;
	public GameObject metk;
	public float force;
	public GameObject Tmetk;
	private float nextFire;
	private float TnextFire;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) 
			{
			nextFire = Time.time + fireRate;
			GameObject klon;
			Rigidbody currBall;
			//index = 0;
			klon = Instantiate (metk, transform.position, transform.rotation) as GameObject;
			klon.rigidbody.velocity = transform.TransformDirection (Vector3.right * force);
			}
		/*if (Time.time > TnextFire)
				{
						TnextFire = Time.time + TfireRate;
						GameObject tBall;
						tBall = Instantiate (Tmetk, transform.position, transform.rotation) as GameObject;
						tBall.rigidbody.velocity = transform.TransformDirection (Vector3.right * force);
				}*/
	}
}
