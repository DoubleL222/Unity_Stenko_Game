using UnityEngine;
using System.Collections;

public class DroneBoltMover : MonoBehaviour {

		public float speed;
	private int orientation;
		// Use this for initialization

		void Start () {
			GameObject player = GameObject.Find ("roBot");
			Vector3 smer = -transform.position + player.transform.position + new Vector3(0,0.75f, 0);
			smer.Normalize ();
			float kot = Vector3.Angle(new Vector3(1, 0,0), smer );
			//transform.Rotate (new Vector3(0,0,kot));
			rigidbody.velocity = smer * speed;
			
			
		}
		void OnTriggerEnter(Collider other){
			if(other.tag=="Drone"){
				return;
			}
			Destroy (gameObject);
		}
		// Update is called once per frame
		
	}
