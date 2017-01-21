using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public bool duckCrate;

	public void OnBreak() {
		if (duckCrate) {
			DuckManager.main.AddDuck(transform.position.Vec2());
		}
	}
}
