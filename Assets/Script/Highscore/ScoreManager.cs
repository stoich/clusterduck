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

	void Start() {
		UpdateAll();
	}

	void OnDestroy() {

		if (main == this) {
			main = null;
		}

	}

	public void LoseDuck() {
		
		mainScore += currentScore * Multiplier();
		currentScore = 0f;
		UpdateAll();

	}

	float Multiplier() {
		return Mathf.Max(1f, 1f + (duckCount - 1) / 10f);
	}

	public void AddPoints(float points) {
		currentScore += points;
		UpdateCurrentScoreBox();
	}

	public void UpdateDuckCount() {

		duckCount = DuckManager.main.duckList.Count;
		duckCountBox.text = Multiplier().ToString("n1");

	}

	void UpdateCurrentScoreBox() {
		currentScoreBox.text = currentScore.ToString("n0");
	}

	void UpdateMainScoreBox() {
		mainScoreBox.text = mainScore.ToString("n0");
	}

	void UpdateAll() {

		UpdateDuckCount();
		UpdateCurrentScoreBox();
		UpdateMainScoreBox();
	
	}



}
