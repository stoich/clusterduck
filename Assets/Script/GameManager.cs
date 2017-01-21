using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager main; 
	public Animator startGameAnimator;
	public GameObject obstacleGenerator;
	bool started;

	bool gameStarted = false; 

	void Awake () {
		if (main != null) {
			Destroy(gameObject);
		}
		main = this;
	}

	void OnDestroy() {
		if (main == this) {
			main = null;
		}
	}

	public void TryStartGame() {

		print("Start?");
		if (started) return;

		print("Start!");
		started = true;
		obstacleGenerator.SetActive(true);
		startGameAnimator.SetBool("started", true);

	}
}