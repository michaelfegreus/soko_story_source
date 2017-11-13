using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_player_control : MonoBehaviour {

	float inputX = 0f;
	float inputY = 0f;

	float targetMoveSpeed;
	public float baseMoveSpeed;
	public float accelerationRate;
	public float deccelerationRate;
	float currentMoveSpeed = 0f;

	Rigidbody rb;

	//public bool onGround = true;

	Vector3 movement;

	void Start(){
		targetMoveSpeed = baseMoveSpeed;

		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		movement = new Vector3 (inputX, 0.0f, inputY);

		transform.rotation = Quaternion.LookRotation(movement);

		Debug.Log ("Current Move Speed: " + currentMoveSpeed);

	}

	void FixedUpdate (){

	

		/*Ray groundRay = new Ray(transform.position, -transform.up);
		if (Physics.Raycast(groundRay, out hit, 1000f)) {
			// Sets you to heightAdjust's distance above the ground.
		}*/


		// Move input that pushes the character forward towards the direction faced
		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			targetMoveSpeed = baseMoveSpeed;
			if (currentMoveSpeed < targetMoveSpeed) { // Must accelerate.
				currentMoveSpeed = Mathf.Lerp (currentMoveSpeed, targetMoveSpeed, Time.deltaTime * accelerationRate);
			}
			// Apply force to begin moving!
			rb.AddForce (transform.forward * currentMoveSpeed, ForceMode.Impulse);
		} else {
			/*if (currentMoveSpeed > 0f) { // Must deccelerate.
				currentMoveSpeed = 0f;
				rb.velocity = new Vector3 (0f, 0f, 0f);
			}*/
			currentMoveSpeed = 0f;
			rb.velocity = new Vector3 (0f, 0f);

		}
	
	}
}
