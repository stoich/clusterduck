using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpriteManager : MonoBehaviour {

	public static DuckSpriteManager main; 
	public Sprite[] body, outfits;

	[Range(0f, 1f)]
	public float specialChance = 0.3f;

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

	public Sprite GetBody() {
		return RandomFromSpriteArray(body);
	}

	public Sprite GetOutfit() {
		return RandomFromSpriteArray(outfits);
	}

	Sprite RandomFromSpriteArray(Sprite[] array) {
		
		if (array.Length > 1 && Random.Range(0f,1f) < specialChance) {

			return array[Random.Range(1, array.Length)];

		}

		return array[0];
	}

}
