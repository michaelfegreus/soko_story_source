using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_ground_check : MonoBehaviour {

	Rigidbody rb;
	RaycastHit hit;

	public float heightAdjust;
	public float myGravity;

	public bool onGround;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		// Checks to see if you're on the ground and not falling currently.
		if (rb.velocity.y < 0.05f && Vector3.Distance (transform.position, hit.point) <= heightAdjust) {
			onGround = true;
			transform.position = new Vector3 (transform.position.x, hit.point.y + heightAdjust, transform.position.z);
			// Ground drag back on
			//Debug.Log("On Ground reset accessed");
		} else if (Vector3.Distance (transform.position, hit.point) > heightAdjust + 0.05f) {
			onGround = false;
		}
	}

	void FixedUpdate(){

		Ray groundRay = new Ray (transform.position, -transform.up);
		if (Physics.Raycast (groundRay, out hit, 1000f)) {
			// Sets you to heightAdjust's distance above the ground.
		}

		// Always apply significant gravity if not on ground
		if (!onGround) {
			rb.AddForce (-transform.up * myGravity, ForceMode.Impulse);
		}

		//Debug.Log (hit.point);
		Debug.DrawLine(transform.position, hit.point, Color.red);
	}
}
