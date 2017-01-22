using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	public static ParticleManager main;
	public ParticleSystem[] boxParticles;
	public GameObject boxPartObject;

	void Awake () {
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

	public void BreakCrate(Vector3 position) {

		boxPartObject.transform.position = position;
		foreach (ParticleSystem box in boxParticles) {
			box.Emit(1);
		}
	}

}