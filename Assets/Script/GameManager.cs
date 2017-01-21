using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

	public static GameManager main; 
	public Animator startGameAnimator, gameOverAnimator;
	public GameObject obstacleGenerator;

	bool gameStarted = false;
	bool gameEnded = false;
	bool readyToRestart = false;

	void Awake () {
		if (main != null) {
			Destroy(gameObject);
		}
		main = this;
	}

	void Update() {
		if (gameEnded && readyToRestart && Input.GetMouseButtonDown(0)) {
			StartCoroutine(Restart());
		}
	}

	void OnDestroy() {
		if (main == this) {
			main = null;
		}
	}

	public void TryStartGame() {

		if (gameStarted) return;

		gameStarted = true;
		obstacleGenerator.SetActive(true);
		startGameAnimator.SetBool("started", true);

	}

	public void TryGameOver() {


		if (!gameStarted || gameEnded) return;

		print(gameStarted + ", " + gameEnded);
		gameEnded = true;
		obstacleGenerator.SetActive(false);
		gameOverAnimator.enabled = true;
		gameOverAnimator.SetTrigger("isGameOver");

		StartCoroutine(GameOverClickIgnore());

	}

	IEnumerator GameOverClickIgnore() {

		yield return new WaitForSeconds(1f);
		readyToRestart = true;
	}

	IEnumerator Restart() {

		gameOverAnimator.SetBool("started", true);
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

}