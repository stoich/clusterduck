using UnityEngine;
using System.Collections;


[System.Serializable]
public class SaveFile {
	public float money = 0f;
	public int duckCount = 1;

	public string ToString() {
		return "$" + money.ToString("n0") + " - " + duckCount + " ducks";
	}
}