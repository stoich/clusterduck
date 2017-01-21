using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMotion : MonoBehaviour {

	public Rigidbody2D bodyWithSpeed;
	public GameObject objToRotate, objToBob;
	float lowerLimit = 6f, upperLimit = 30f, maxRotation = 30f, bobFrequency = 1f, bobDisplacement = 0.05f;

	float bobStage = 0f;

	void Update () {

		float rotation = bodyWithSpeed.velocity.magnitude;
		
		rotation -= lowerLimit;
		rotation /= (upperLimit - lowerLimit);
		rotation = Mathf.Clamp(rotation, 0f, 1f);
		rotation = Mathf.Pow(rotation, 0.5f);
		rotation *= maxRotation;

		objToRotate.transform.localEulerAngles = new Vector3(0f, 0f, rotation);
	
		bobStage = (bobStage + Time.deltaTime) % bobFrequency;
		float bob = bobStage / bobFrequency;
		bob *= 2f * Mathf.PI;
		bob = Mathf.Sin(bob);
		bob *= bobDisplacement;

		objToRotate.transform.position = objToRotate.transform.parent.position + new Vector3(0f, bob, 0f);
		print(objToRotate.transform.position);

	}
}
