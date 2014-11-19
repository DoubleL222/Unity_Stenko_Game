// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	private float nextJump;

	void  FixedUpdate (){
		MoveHero();
		JumpHero();
	}
	
	void  PlayAnimation ( string AnimName  ){
		if (!animation.IsPlaying(AnimName))
			animation.CrossFadeQueued(AnimName, 0.3f, QueueMode.PlayNow);
	}
	
	void  CheckForIdle (){
		if (animation.IsPlaying("run")) PlayAnimation("idle");
		if (!animation.isPlaying) animation.Play("idle");
	}
	
	void  MoveHero (){
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f) {
			if (Input.GetAxis("Horizontal") > 0.02f) transform.eulerAngles = new Vector3(0f, 90f, 0f);
			else if (Input.GetAxis("Horizontal") < -0.02f) transform.eulerAngles = new Vector3(0f, -90f, 0f);
			transform.Translate(Vector3.forward * Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime * 3.5f);
			if (!animation.IsPlaying("jump")) PlayAnimation("run");
		}
		else CheckForIdle();
	}

	
	void  JumpHero (){
		if (Input.GetButton("Jump") && nextJump < Time.time) {
			rigidbody.AddForce(Vector3.up * 200);
			PlayAnimation("jump");
			nextJump = Time.time + 1;
			new WaitForSeconds(0.7f); 
			PlayAnimation("idle");
		}
	}
	
	void  OnCollisionEnter ( Collision collision  ){
		foreach( ContactPoint contact in collision.contacts ) {
			if (contact.otherCollider.name == "GameFinish")
				Application.LoadLevel("gameFinish");
		}
	}
}