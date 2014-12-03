using UnityEngine;
using System.Collections;

public class DroneMover : MonoBehaviour {
	public GameObject shot;
	public float fireRate = 0.5f;
	public Transform shotSpawn;
	public float step = 0.05f;
	public float speed = 1.0f;
	public float distance =5.0f;

	private Vector3 startPosition;
	private Vector3 endPosition;
	private float nextFire =0.5f;
	private float direction;
	// Use this for initialization
	void Awake()
	{	
		direction = distance / distance;
		startPosition = transform.position;
		endPosition = startPosition + new Vector3 (distance, 0.0f, 0.0f);
		transform.Rotate (0, 90.0f, 0);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (transform.position == endPosition) {
			endPosition=startPosition;
			startPosition=transform.position;
			transform.Rotate(0, 180.0f, 0);
			direction=direction*-1;

		}
		transform.position = Vector3.MoveTowards (transform.position, endPosition, step);
		GameObject player = GameObject.Find ("roBot");
		float distance = Vector3.Distance (player.transform.position, transform.position);
		if ( Time.time > nextFire && distance < 15.0f) {
			nextFire = Time.time +fireRate;
			GameObject robotMan = GameObject.Find ("roBot");
			Vector3 smer = -transform.position + robotMan.transform.position + new Vector3(0,0.75f, 0);
			smer.Normalize ();
			float kot = Vector3.Angle(new Vector3(direction, 0,0), smer );
			shotSpawn.Rotate(0,0,kot);
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			shotSpawn.Rotate(0,0,-kot);
			//as GameObject;
			
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "robotShot") {
			Destroy (gameObject);	
		}
	}
}
