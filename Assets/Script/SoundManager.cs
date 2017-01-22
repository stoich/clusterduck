using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour {

	public static SoundManager main;

	public AudioSource crateAudio;

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

	public void SmashCrate() {

		crateAudio.pitch = Random.Range(0.8f,1.2f);
		crateAudio.Play();

	}

}