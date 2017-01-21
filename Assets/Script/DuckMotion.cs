using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMotion : MonoBehaviour {

	public Rigidbody2D bodyWithSpeed;
	public GameObject objToRotate, objToBob;
	public float maxRotation = 30f, bobFrequency = 1f, bobDisplacement = 0.05f, sideBobAmount = 10f;
	public SpeedManager speedManager;

	float bobStage = 0f;

	void Update() {

		bool sideBob = true;

		if (speedManager != null) {

			sideBob = false;
			Tilt();
		
		}

		Bob(sideBob);

	}

	void Tilt () {

		float rotation = bodyWithSpeed.velocity.magnitude;
		
		rotation -= speedManager.sonicTreshold;
		rotation /= ( speedManager.terminalVelocity - speedManager.sonicTreshold);
		rotation = Mathf.Clamp(rotation, 0f, 1f);
		rotation = Mathf.Pow(rotation, 0.5f);
		rotation *= maxRotation;

		objToRotate.transform.localEulerAngles = new Vector3(0f, 0f, rotation);

	}

	void Bob(bool sideBob) {

		bobStage = (bobStage + Time.deltaTime) % (bobFrequency * 2f);
		float bob = bobStage / bobFrequency;
		bob *= 2f * Mathf.PI;
		bob = Mathf.Sin(bob);
		bob *= bobDisplacement;

		objToRotate.transform.position = objToRotate.transform.parent.position + new Vector3(0f, -bob, 0f);

		if (sideBob) {

			float rotationAmount = 1 - bobStage / bobFrequency;
			rotationAmount = Mathf.Abs( rotationAmount ) - 0.5f;
			rotationAmount *= sideBobAmount;

			objToRotate.transform.localEulerAngles = new Vector3(0f, 0f, rotationAmount);
		
		}
	
	}
}
