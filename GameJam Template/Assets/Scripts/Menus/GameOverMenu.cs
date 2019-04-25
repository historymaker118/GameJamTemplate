using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	public Animator transition;
	public Text scoreText;
	public InputField playerName;
	public Scoreboard scoreboard;
	public GameObject scoreboardUI;

	private int finalScore = 0;

	void Start(){
		ScoreGame();
	}

	private void ScoreGame(){
		if (scoreText != null){
			finalScore = Scorekeeper.Instance.FetchScore();
		}
		scoreText.text = finalScore.ToString();
		if (scoreboard.CheckHighscore(finalScore)){
			scoreboardUI.SetActive(true);
			playerName.gameObject.SetActive(true);
		}
	}

	public void OnPlayerNameEntered(){
		if (playerName.text == ""){
			playerName.text = "Player";
		}
		Debug.Log("Score: "+finalScore + ", PlayerName: " + playerName.text);
		scoreboard.AddScoreboardEntry(finalScore, playerName.text);
	}

	public void StartAgain(){
		StartCoroutine(transitionScene(2f, "Main"));
	}

	public void ShowScoreboard(){
		scoreboardUI.SetActive(!scoreboardUI.activeSelf);
	}

	public void QuitToMenu(){
		StartCoroutine(transitionScene(2f, "Menu"));
	}

	private IEnumerator transitionScene(float duration, string sceneName){
		transition.SetTrigger("FadeOut");
		float elapsed = 0;
		while (elapsed < duration){
			elapsed += Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadSceneAsync(sceneName);
	}
}
