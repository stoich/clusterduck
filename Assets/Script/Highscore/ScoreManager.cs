using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager main;

	public GameObject scoreTextPrefab;

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

	public void BreakBox(Vector3 position) {

		int earnedPoints = Mathf.RoundToInt(Random.Range(minBoxScore, maxBoxScore) * multiplier);

		AddPoints(earnedPoints);

		GameObject go = (GameObject)Instantiate(scoreTextPrefab, new Vector3(0, 0, -1000), new Quaternion());
		CrateText text = go.GetComponent<CrateText>();
		text.Setup(position, "$" + earnedPoints.ToString("n0"));
		
	}

	void UpdateMainScoreBox() {
		mainScoreBox.text = mainScore.ToString("n0");
	}



}
