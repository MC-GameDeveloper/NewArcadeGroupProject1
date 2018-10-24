using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public float followSpeed;

	// Use this for initialization

	
	// Update is called once per frame
	void FixedUpdate () {
		float superDistance = Vector2.Distance (transform.position, player.transform.position);

		transform.position = Vector3.Lerp (transform.position, player.transform.position, followSpeed * superDistance * Time.deltaTime);
	}
}
