using UnityEngine;

public class BallController : MonoBehaviour {

	public float force;
	public float maxSpeed;

	private Rigidbody rb;
	[SerializeField]
	private float xDir = 1;

	void Awake() {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Start() {
		if (transform.position.x < 0)
			xDir = 1;
		else if (transform.position.x > 0)
			xDir = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.isGameStarted && Input.GetKey(KeyCode.Space)) {
			Vector3 forceDir = Vector3.zero;
			forceDir = new Vector3(xDir, 1, 0);
			rb.AddForce(forceDir * force, ForceMode.Impulse);
			GameController.isGameStarted = true;
		}
	}

	void OnCollisionEnter(Collision collision) {

		GameObject collidedObject = collision.gameObject;
		if (collidedObject.tag.Equals("Racket")) {
			Vector3 forceDir;
			if (transform.position.y > collidedObject.transform.position.y)
				forceDir = new Vector3(xDir, 1, 0);
			else if (transform.position.y < collidedObject.transform.position.y)
				forceDir = new Vector3(xDir, -1, 0);
			else
				forceDir = new Vector3(xDir, 0, 0);
			if (rb.velocity.sqrMagnitude < maxSpeed) {
				force += .2f;
				rb.AddForce(forceDir * force, ForceMode.Impulse);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Net")) {
			xDir = -xDir;
		}
	}
}
