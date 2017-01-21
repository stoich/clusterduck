using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager main;

	float mainScore = 0f;
	float currentScore = 0f;
	int duckCount = 1;

	void Start () {
		
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

	}

	public void UpdateDuckCount() {
		duckCount = DuckManager.main.duckList.Size();
	}

	float Multiplier(int duckCount) {
		return 1f + (duckCount - 1) / 10f;
	}



}
