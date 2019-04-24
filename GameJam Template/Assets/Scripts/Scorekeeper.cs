using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {

	public static Scorekeeper Instance;

	private int score;
	private Text scoreText;

	void Awake(){
		if (Instance == null){
			Instance = this;
			DontDestroyOnLoad(this);
		} else {
			GameObject.Destroy(Instance);
		}
		scoreText = GetComponentInChildren<Text>();
	}


	public void UpdateScore (int amount){
		score += amount;
		if (scoreText != null){
			scoreText.text = score.ToString();
		}
	}

	public int FetchScore(){
		return score;
	}
}
