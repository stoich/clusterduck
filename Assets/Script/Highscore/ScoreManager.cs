using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager main;

	float mainScore = 0f;

	public Text mainScoreBox;

	public float minBoxScore, maxBoxScore, multiplier = 1f;

	void Awake () {
		
		if (main != null) {
			Destroy(gameObject);
		}
		main = this;
	
	}

	void Start() {
		UpdateMainScoreBox();
	}

	void OnDestroy() {

		if (main == this) {
			main = null;
		}

	}

	public void AddPoints(float points) {
		mainScore += points;
		UpdateMainScoreBox();
	}

	public void BreakBox() {
		AddPoints(Mathf.RoundToInt(Random.Range(minBoxScore, maxBoxScore) * multiplier));
	}

	void UpdateMainScoreBox() {
		mainScoreBox.text = mainScore.ToString("n0");
	}



}
