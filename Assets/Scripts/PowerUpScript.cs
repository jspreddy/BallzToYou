using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public int duration = 3;
	public int rotationSpeed = 10;

	// Update is called once per frame
	void Update () {
		//rotate powerup per time.
		transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
		// animate position to lerp along y axis.

	}

	// on colision with player. add powerup to player object powerups list.
	//destroy game object.

}
