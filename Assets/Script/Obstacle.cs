using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public bool duckCrate;

	public void OnBreak(float otherVelocity) {

		ParticleManager.main.BreakCrate(transform.position);

		ShockWave.Blast(transform.position.Vec2(), 2f, otherVelocity / 4f);

		ScoreManager.main.BreakBox(transform.position);

		if (duckCrate) {
			DuckManager.main.AddDuck(transform.position.Vec2());
		}
	}
}
