using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private const string HIGH_SCORE = "High Score";
	public static GameManager instance;
	private void Awake() {
		_MakeSingerInstance();
		_IsGameStartForTheFirstTime();
	}

	public void _MakeSingerInstance() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		}
		else {
			Destroy(this);
		}
	}

	public void _IsGameStartForTheFirstTime() {
		if(PlayerPrefs.HasKey("_IsGameStartForTheFirstTime")) {
			PlayerPrefs.SetInt(HIGH_SCORE, 0);
			PlayerPrefs.SetInt("_IsGameStartForTheFirstTime", 0);
		}
	}

	public void setHighScore(int score) {
		PlayerPrefs.SetInt(HIGH_SCORE, score);
	}

	public int getHighScore(){
		return PlayerPrefs.GetInt(HIGH_SCORE);
	}

}
