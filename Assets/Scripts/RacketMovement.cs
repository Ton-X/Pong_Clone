using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	public float speed;
	public int playerNumber;
	public float maxY;
	public float minY;

	private KeyCode upKey;
	private KeyCode downKey;
	
	void Start() {
		if (playerNumber == 1) {
			upKey = KeyCode.W;
			downKey = KeyCode.S;
		} else {
			upKey = KeyCode.UpArrow;
			downKey = KeyCode.DownArrow;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		if (Input.GetKey(upKey) && currentPosition.y <= maxY) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(downKey) && currentPosition.y >= minY) {
			transform.position += -Vector3.up * speed * Time.deltaTime;
		}
	}
}
