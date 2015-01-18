using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {

	
	public Rigidbody shot;
	public Rigidbody shot1;
	public Rigidbody shot2;
	public Rigidbody shot3;
	public Rigidbody shot4;

	private ArrayList balls;
	private int index;

	// Use this for initialization
	void Start () {
		balls=new ArrayList();
		balls.Add (shot);
		balls.Add (shot1);
		balls.Add (shot2);
		balls.Add (shot3);
		balls.Add (shot4);
	}
	
	// Update is called once per frame
	void Update () {
	/*	if (Time.time > nextFire)
		{
			GameObject klon;
			nextFire = Time.time + fireRate;
			klon = Instantiate(shot, transform.position, transform.rotation) as GameObject;
			klon.rigidbody.velocity = transform.TransformDirection(Vector3.up * ballForce);
		}*/
	}
	public void SpawnBall(GameObject spawnPosition, float shotAngle, float force){
		Rigidbody klon;
		Rigidbody currBall;
		index = Random.Range (0, balls.Count);
		//index = 0;
		currBall = balls [index] as Rigidbody;
		klon = Instantiate(currBall, spawnPosition.transform.position, spawnPosition.transform.rotation) as Rigidbody;
		klon.velocity = transform.TransformDirection(new Vector3 (shotAngle, 1, 0) * force);
	}
}
