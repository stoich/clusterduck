using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager main;

	float mainScore = 0f;
	float currentScore = 0f;
	int duckCount = 1;

	public Text mainScoreBox, currentScoreBox, duckCountBox;

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

	public void LoseDuck() {
		
		mainScore += currentScore * Multiplier(duckCount);
		currentScore = 0f;
		UpdateDuckCount();
		UpdateCurrentScoreBox();
		UpdateMainScoreBox();

	}

	public void UpdateDuckCount() {

		duckCount = DuckManager.main.duckList.Count;
		duckCountBox.text = "x " + duckCount.ToString("n1");

	}

	float Multiplier(int duckCount) {
		return 1f + (duckCount - 1) / 10f;
	}

	public void AddPoints(float points) {
		currentScore += points;
		UpdateCurrentScoreBox();
	}

	void UpdateCurrentScoreBox() {
		currentScoreBox.text = currentScore.ToString("n0");
	}

	void UpdateMainScoreBox() {
		mainScoreBox.text = mainScore.ToString("n0");
	}



}
