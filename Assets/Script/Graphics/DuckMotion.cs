﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMotion : MonoBehaviour {

	public Rigidbody2D bodyWithSpeed;
	public GameObject objToRotate, objToBob;
	public float maxRotation = 30f, bobFrequency = 1f, bobDisplacement = 0.05f, sideBobAmount = 10f;
	public SpeedManager speedManager;
	public ParticleSystem trail;
	bool particlesOn;
	float bobSpeed;

	float bobStage = 0f;

	public float minScale = 0.7f, maxScale = 0.9f;
	float scale;
	bool facingLeft;

	void Start() {
		bobSpeed = Random.Range(0.7f, 1.3f);
		scale = Random.Range(minScale, maxScale);
		transform.localScale = new Vector3(scale, scale, scale);
	}

	void Update() {

		bool sideBob = true;

		if (speedManager != null) {

			sideBob = false;
			Tilt();
		
		}

		if (bodyWithSpeed.velocity.x < 0f && !facingLeft) {
			facingLeft = true;
			transform.localScale = new Vector3(-scale, scale, scale);
		}
		if (bodyWithSpeed.velocity.x > 0f && facingLeft) {
			facingLeft = false;
			transform.localScale = new Vector3(scale, scale, scale);
		}

		Bob(sideBob);

		if (trail != null) {
			CheckParticles();
		}

	}

	void Tilt () {

		float rotation = bodyWithSpeed.velocity.magnitude;
		
		rotation -= DuckManager.main.sonicTreshold;
		rotation /= ( DuckManager.main.terminalVelocity - DuckManager.main.sonicTreshold);
		rotation = Mathf.Clamp(rotation, 0f, 1f);
		rotation = Mathf.Pow(rotation, 0.5f);
		rotation *= maxRotation;

		objToRotate.transform.localEulerAngles = new Vector3(0f, 0f, rotation);

	}

	void Bob(bool sideBob) {

		bobStage = (bobStage + Time.deltaTime * bobSpeed) % (bobFrequency * 2f);
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

	void CheckParticles() {
		//TODO: Use a better way of checking this
		if (particlesOn != bodyWithSpeed.velocity.magnitude > DuckManager.main.sonicTreshold) {
			
			if (particlesOn) {
			
				particlesOn = false;
				trail.Stop();

			} else {

				particlesOn = true;
				trail.Play();

			}
		}
	}
}
