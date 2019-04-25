using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

	public Transform container;
	public Transform entryTemplate;

	private float templateHeight = 25f;
	private List<ScoreboardEntry> scoreboardEntryList;
	private List<Transform> scoreboardEntryTransformList;

	private void Awake(){
		ReloadScoreboard();
	}

	private void LoadScores(){
		entryTemplate.gameObject.SetActive(false);

		if (PlayerPrefs.HasKey("highscores")){
			string jsonString = PlayerPrefs.GetString("highscores");
			HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
			scoreboardEntryList = highscores.highscoreEntryList;
		} else {
			scoreboardEntryList = new List<ScoreboardEntry>(){
				new ScoreboardEntry {score = 9999, name = "Never"},
				new ScoreboardEntry {score = 8888, name = "Gonna"},
				new ScoreboardEntry {score = 7777, name = "Give"},
				new ScoreboardEntry {score = 6666, name = "You"},
				new ScoreboardEntry {score = 5555, name = "Up"},
				new ScoreboardEntry {score = 4444, name = "Never"},
				new ScoreboardEntry {score = 3333, name = "Gonna"},
				new ScoreboardEntry {score = 2222, name = "Let"},
				new ScoreboardEntry {score = 1111, name = "You"},
			};
			HighScores highscores = new HighScores { highscoreEntryList = scoreboardEntryList };
			string json = JsonUtility.ToJson(highscores);
			PlayerPrefs.SetString("highscores", json);
			PlayerPrefs.Save();
		}

		for (int i=0; i<scoreboardEntryList.Count; i++){
			for (int j=i+1; j<scoreboardEntryList.Count; j++){
				if (scoreboardEntryList[j].score > scoreboardEntryList[i].score){
					var tmp = scoreboardEntryList[i];
					scoreboardEntryList[i] = scoreboardEntryList[j];
					scoreboardEntryList[j] = tmp;
				}
			}
		}

		scoreboardEntryTransformList = new List<Transform>();
		int scoreCount = 0;
		foreach (ScoreboardEntry scoreEntry in scoreboardEntryList){
			if (scoreCount >= 10){
				return;
			}
			CreateScoreboardEntryTransform(scoreEntry, container, scoreboardEntryTransformList);
			scoreCount ++;
		}
	}

	private void CreateScoreboardEntryTransform(ScoreboardEntry entry, Transform container, List<Transform> transformList){
		Transform entryTransform = Instantiate(entryTemplate, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
		entryTransform.gameObject.SetActive(true);

		entryTransform.GetComponent<ScoreboardEntryUI>().nameText.text = entry.name;
		entryTransform.GetComponent<ScoreboardEntryUI>().scoreText.text = entry.score.ToString();

		transformList.Add(entryTransform);
	}

	public void AddScoreboardEntry(int score, string name){
		//Create scoreboard entry
		ScoreboardEntry scoreboardEntry = new ScoreboardEntry { score = score, name = name };

		//Load saved highscores
		string jsonString = PlayerPrefs.GetString("highscores");
		HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

		//Add new entry to scores
		highscores.highscoreEntryList.Add(scoreboardEntry);

		//Save updated highscores
		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highscores", json);
		PlayerPrefs.Save();

		foreach (Transform scoreboardEntryTransform in scoreboardEntryTransformList){
			GameObject.Destroy(scoreboardEntryTransform.gameObject);
		}

		LoadScores();
	}

	private void ReloadScoreboard(){
		if (scoreboardEntryTransformList != null){
			foreach (Transform scoreboardEntryTransform in scoreboardEntryTransformList){
				GameObject.Destroy(scoreboardEntryTransform.gameObject);
			}
		}
		LoadScores();
	}

	public bool CheckHighscore(int score){
		if (score <= 0){
			return false;
		}
		if (scoreboardEntryList.Count < 10){
			return true;
		}
		//sort existing highscores
		for (int i=0; i<scoreboardEntryList.Count; i++){
			for (int j=i+1; j<scoreboardEntryList.Count; j++){
				if (scoreboardEntryList[j].score > scoreboardEntryList[i].score){
					var tmp = scoreboardEntryList[i];
					scoreboardEntryList[i] = scoreboardEntryList[j];
					scoreboardEntryList[j] = tmp;
				}
			}
		}
		return (score > scoreboardEntryList[9].score);
	}

	public void ResetScoreboard(){
		PlayerPrefs.DeleteKey("highscores");
		PlayerPrefs.Save();
		ReloadScoreboard();
	}

	private class HighScores {
		public List<ScoreboardEntry> highscoreEntryList;
	}

	[System.Serializable]
	private class ScoreboardEntry {
		public int score;
		public string name;
	}
}



