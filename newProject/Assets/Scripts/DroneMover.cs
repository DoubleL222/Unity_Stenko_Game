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
	// Use this for initialization
	void Awake()
	{	
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

		}
		transform.position = Vector3.MoveTowards (transform.position, endPosition, step);
		if ( Time.time > nextFire) {
			nextFire = Time.time +fireRate;

			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			//as GameObject;
			
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "robotShot") {
			Destroy (gameObject);	
		}
	}
}
