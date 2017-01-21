using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour {

	// Use this for initialization
	public static void Blast (Vector2 position, float radius, float power) {
		GameObject[] boxes = GameObject.FindGameObjectsWithTag("Obstacle");
		foreach (GameObject box in boxes) {

			Vector2 difference = box.transform.position.Vec2() - position;

			if (difference.magnitude <= radius) {

				Vector2 forceVector = difference.normalized * power;
				box.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
			}

		}
	}
}
