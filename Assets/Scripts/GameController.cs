using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static bool isGameStarted = false;

	public int scoreToWin = 10;
	public GameObject backgroundPanel;
	public Text startText;
	public Text winText;
	public Text scoreText1;
	public Text scoreText2;
	public Transform racket1Transform;
	public Transform racket2Transform;
	public GameObject ballPrefab;

	private int score1;
	private int score2;

	void Start() {
		SpawnBall(1);
	}

	void Update() {
		if (isGameStarted) {
			backgroundPanel.SetActive(false);
			startText.gameObject.SetActive(false);
		}

		if (score1 == scoreToWin) {
			Winner(1);
		} else if (score2 == scoreToWin) {
			Winner(2);
		}
	}

	public void UpdateScore(int fieldSide) {
		if (fieldSide == 1) {
			scoreText2.text = ++score2 + "";
		} else {
			scoreText1.text = ++score1 + "";
		}

		SpawnBall(fieldSide);
		isGameStarted = false;
	}

	private void SpawnBall(int fieldSide) {
		Vector3 spawnPosition;
		if (fieldSide == 1) {
			spawnPosition = new Vector3(racket1Transform.position.x + .3f, racket1Transform.position.y, 0);
		} else {
			spawnPosition = new Vector3(racket2Transform.position.x - .3f, racket2Transform.position.y, 0);
		}

		Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
	}

	private void Winner(int player) {
		backgroundPanel.SetActive(true);
		winText.gameObject.SetActive(true);
		winText.text = "PLAYER " + player + "WINS!";
		Time.timeScale = 0;
	}
}
