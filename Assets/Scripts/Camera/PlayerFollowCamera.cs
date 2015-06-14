using UnityEngine;
using System.Collections;

public class PlayerFollowCamera : MonoBehaviour {

	private GameObject player;
	public float maxFollowDistance=6.0f;
	private float moveDistance = 0.01f;
	private float catchupTime = 0.5f;
	// Use this for initialization
	void Start () {
		moveDistance = 0.01f;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate () {
		this.transform.LookAt (player.transform, Vector3.up);


		float dist = Vector3.Distance (this.transform.position, player.transform.position);
		float maxMoveDist = dist-this.maxFollowDistance;

		if( dist > maxFollowDistance ){
			this.moveDistance = maxMoveDist / catchupTime * Time.fixedDeltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, this.moveDistance);
		}
		else{
			this.moveDistance = 0.01f;
		}
		//Debug.Log ("<color=blue>MoveDist: </color> "+this.moveDistance);
	}
}
