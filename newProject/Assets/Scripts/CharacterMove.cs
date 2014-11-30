// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	public Slider slider;
	public float fireRate = 0.5f;

	public float gravityK=0.1f;
//	public float flashSpeed =5f;
//	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);
	public float maxFuel = 100f;
	public float speed =6f;
	public float speedVertical =6f;
	public GameObject shot;
	public Transform shotSpawn;

	Rigidbody playerRigidbody;
	private float nextJump;
	private float fuel;
	float camRayLength=100f;
	private float nextFire =0.5f;
	Vector3 movement;

	void Awake()
	{
		fuel = maxFuel;
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void  FixedUpdate (){

		rigidbody.AddForce(-Vector3.up*9.8f*gravityK);
		float v=Input.GetAxisRaw("Vertical");
		float h=-Input.GetAxisRaw("Horizontal");
		if (v != 0) {
			//fuel=fuel-maxFuel*0.005f;	
			PlayAnimation("jump");
			}
		fuel = fuel -  Mathf.Abs(v);
		if (fuel < 0) {
			v=0;	
			}
		if (v == 0 && fuel<=maxFuel ) {
				fuel += maxFuel * 0.01f;
		}
		MoveHero(h,v);
		print ("fuel: " + fuel);
			//	JumpHero();
		slider.value = fuel/maxFuel*100f;
	}

	void Update(){
		if (Input.GetKeyDown ("space") && Time.time > nextFire) {
			nextFire = Time.time +fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				//as GameObject;
						
		}
	}
	
	void  PlayAnimation ( string AnimName  ){
		if (!animation.IsPlaying(AnimName))
			animation.CrossFadeQueued(AnimName, 0.3f, QueueMode.PlayNow);
	}
	
	void  CheckForIdle (){
		if (animation.IsPlaying("run")) PlayAnimation("idle");
		if (!animation.isPlaying) animation.Play("idle");
	}
	
/*	void  MoveHero (){
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f) {
			if (Input.GetAxis("Horizontal") > 0.02f) transform.eulerAngles = new Vector3(0f, 90f, 0f);
			else if (Input.GetAxis("Horizontal") < -0.02f) transform.eulerAngles = new Vector3(0f, -90f, 0f);
			transform.Translate(Vector3.forward * Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime * 3.5f);
			if (!animation.IsPlaying("jump")) PlayAnimation("run");
		}
		else CheckForIdle();
	}*/

	void  MoveHero (float h, float v){
		if (Mathf.Abs (h) > 0.2f || Mathf.Abs (v) > 0.2f) {
						if (h < 0.02f)
				transform.eulerAngles = new Vector3 (0f, -170.6f , 0f);
						else if (h > -0.02f)
				transform.eulerAngles = new Vector3 (0f, 0.2f, 0f);

						movement.Set (-h, v, 0f);
						movement = movement.normalized * speed * Time.deltaTime;
						playerRigidbody.MovePosition (transform.position + movement);
					//	rigidbody.AddForce( Physics.gravity );
						if (!animation.IsPlaying ("jump"))	PlayAnimation ("loop_run_funny");

				}

	
			//	CheckForIdle ();
		}
	
	void  JumpHero (){
		/*if (Input.GetButton("Jump") && nextJump < Time.time) {
			transform.Translate(Vector3.up * 50 * Time.deltaTime, Space.World);
			//rigidbody.AddForce(Vector3.up * 200);
			PlayAnimation("jump");
			nextJump = Time.time + 1;
			new WaitForSeconds(0.7f); 
			PlayAnimation("idle");*/
		//if (Input.GetKeyDown("space")) transform.Translate(Vector3.up * Mathf.Abs(Input.GetKeyDown("space")) * Time.deltaTime * 3.5f);

	}
	
	void  OnCollisionEnter ( Collision collision  ){
		foreach( ContactPoint contact in collision.contacts ) {
			if (contact.otherCollider.name == "GameFinish")
				Application.LoadLevel("gameFinish");
		}
	}
}