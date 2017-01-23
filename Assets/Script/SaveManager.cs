using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

	public static SaveManager main; 
	public static SaveFile saveFile;

	void Awake () {
		if (main != null) {
			Destroy(gameObject);
		}
		main = this;

	}

	void Start() {
		Load();
	}

	void OnDestroy() {
		if (main == this) {
			main = null;
		}
	}

	public void Save() {

		GameDataToSave();

	    BinaryFormatter bf = new BinaryFormatter();
	    FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
	    bf.Serialize(file, SaveManager.saveFile);
	    file.Close();
	    Debug.Log("Saved!");

	}

	public void Load() {

	    if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
	        BinaryFormatter bf = new BinaryFormatter();
	        FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
	        saveFile = (SaveFile) bf.Deserialize(file);
	        file.Close();
	        print("Loaded savefile: " + saveFile.ToString());
	    } else {
	    	print("No save loaded");
	    	saveFile = new SaveFile();
	    }

	    OnLoad();

	}

	void OnLoad() {

	    SaveDataToGame();
	    DuckManager.main.PlaceDucks();

	}

	void GameDataToSave() {
		saveFile.money = ScoreManager.main.mainScore;
		saveFile.duckCount = DuckManager.main.duckList.Count;
	}

	void SaveDataToGame() {
		ScoreManager.main.mainScore = saveFile.money;
		DuckManager.main.startingDuckCount = saveFile.duckCount;
	}
}