using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSprite : MonoBehaviour {

	public SpriteRenderer body, outfit;

	void Start () {

		body.sprite = DuckSpriteManager.main.GetBody();
		outfit.sprite = DuckSpriteManager.main.GetOutfit();

	}

}
