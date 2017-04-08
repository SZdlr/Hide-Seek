using UnityEngine;
using System.Collections;

public class CharacterSideways : MonoBehaviour {

	public bool grounded = false;
	private bool jump = false;
	public float jumpForceFactor = 1.0f;
	public float gravity = 9.81f;

	private float controlFactor = 0.0f;
	public float airControl = 0.08f;
	public float groundControl = 1f;


	private float moveAxis = 0.0f;
	public float moveForceFactor = 1.0f;


	// Update pro Frame > zuverlässige Abfrage von Eingaben
	//zum Abhören von Tasten
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(grounded) {
				jump = true;
			}
		} 
		moveAxis = Input.GetAxis ("Horizontal");
	
	}
	
	// physikalische Kräfte im Fixed Update anwenden > Berechnung in der Physik Engine parallel zu Update
	//für physikalische Berechnungen
	void FixedUpdate () {

		// Springen durch Kraftimpuls, wenn Player nicht in der Luft 
		if (grounded) {
			if(jump){
				Vector3 jumpForce = new Vector3 (0,1,0) * jumpForceFactor * controlFactor;
				rigidbody.AddForce (jumpForce, ForceMode.VelocityChange);
				jump = false;
			}
		}

		// Bewegungsgeschwindigkeit	
		Vector3 moveForce = new Vector3 (0,0,moveAxis) * moveForceFactor * controlFactor;
		rigidbody.AddRelativeForce (moveForce, ForceMode.Acceleration);
		showForceVector = moveForce;

		// Schwerkraft selbst berechnen --> mehr Kontrollmöglichkeit
		rigidbody.AddForce (new Vector3(0,-1 * gravity * rigidbody.mass,0));
	}


	void OnCollisionStay () {
						grounded = true;
						controlFactor = groundControl;

	}
	void OnCollisionExit () {
		grounded = false;
		controlFactor = airControl;
	}


	// Visualisiert Kraftvektor
	public Vector3 showForceVector;
	void OnDrawGizmos(){
		Gizmos.DrawLine(rigidbody.transform.TransformPoint(rigidbody.centerOfMass), rigidbody.transform.TransformPoint(rigidbody.centerOfMass+showForceVector));
	}

}
