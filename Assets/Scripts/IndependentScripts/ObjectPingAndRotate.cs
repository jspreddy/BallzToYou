using UnityEngine;
using System.Collections;

public class ObjectPingAndRotate : MonoBehaviour {
	
	//
	public float rotationSpeedMultiplier = 50f;
	public float pingSpeedMultiplier = 5f;
	public float pingDistanceMultiplier = 0.5f;

	// used in internal calculations.
	private Vector3 initPosition;


	// Use this for initialization
	void Start () {
		initPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, rotationSpeedMultiplier * Time.deltaTime);
		transform.localPosition = new Vector3( initPosition.x, initPosition.y +( pingDistanceMultiplier * Mathf.Sin (Time.timeSinceLevelLoad * pingSpeedMultiplier)), initPosition.z );
	}
}
