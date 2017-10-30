using UnityEngine;

public class GoalController : MonoBehaviour {

	public int side;

	private GameController gameController;

	void Awake() {
		gameController = FindObjectOfType<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
		gameController.UpdateScore(side);
	}
}
