using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField] private Button btn;

    [SerializeField] private Text score;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text bestScore, endScore;

	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		gameOverPanel.SetActive(false);
        _MakeInstance();
	}

	public void _MakeInstance() {
		if (instance == null) instance = this;
	}

	public void _StartButton() {
		Time.timeScale = 1;
		btn.gameObject.SetActive(false);
	}
	
	public void _SetScore(int v_score) {
		score.text = v_score.ToString();

	}
	
	public void _ShowGameoverPanel(int v_score) {
        gameOverPanel.SetActive(true);
        endScore.text = v_score.ToString();
		if(GameManager.instance != null){
			if (GameManager.instance.getHighScore() < v_score) {
				GameManager.instance.setHighScore(v_score);
			}
			bestScore.text = GameManager.instance.getHighScore().ToString();
		}
	}

	public void _LoadMenu() {
		SceneManager.LoadScene("Menu");
	}

	public void _Pauses() {
		Time.timeScale = 0;
		gameOverPanel.SetActive(true);
	}

	public void _ResumeOrReplay() {
		if (BirdController.instance != null) {
			if (BirdController.instance.isDead) {
				SceneManager.LoadScene("Play");
				
			}
			else {
				btn.gameObject.SetActive(true);
				gameOverPanel.SetActive(false);
			}
		}
	}
}
