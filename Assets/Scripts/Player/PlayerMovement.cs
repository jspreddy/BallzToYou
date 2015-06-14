using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 20.0f;
	public float jumpMagnitude = 20.0f;
	private Rigidbody rb;
	private Transform cameraTransform;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		this.cameraTransform = Camera.main.transform;
	}
	
	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		Vector3 force = new Vector3 (x, 0.0f, z);
		Vector3 forward;
		if (cameraTransform.forward.x == 0.0f && cameraTransform.forward.z == 0.0f) {
			forward = new Vector3(1.0f, 0.0f, 0.0f).normalized;
			Debug.Log("pointing down.");
		} else {
			forward = new Vector3 (cameraTransform.forward.x, 0.0f, cameraTransform.forward.z).normalized;
		}
		Debug.DrawLine (this.transform.position, this.transform.position + forward*20);

		Vector3 left = new Vector3(-forward.z, 0.0f, forward.x).normalized;
		Debug.DrawLine (this.transform.position, this.transform.position + left*20);

		//Debug.DrawLine (this.transform.position, this.transform.position + force *20);

		Vector3 localForce = forward * force.z - left * force.x;
		Debug.DrawLine (this.transform.position, this.transform.position + localForce *20);
		//Vector3.

		rb.AddForce (localForce * movementSpeed);
		if(Input.GetButtonDown("Jump")){
			rb.AddForce(Vector3.up*jumpMagnitude, ForceMode.Impulse);
		}
	}
}
