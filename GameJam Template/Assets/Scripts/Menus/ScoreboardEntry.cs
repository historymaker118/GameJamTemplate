using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardEntry : MonoBehaviour {

	public Text nameText;
	public Text scoreText;

	public string name { get; set; }
	public int score { get; set; }

	void Update(){
		nameText.text = name;
		scoreText.text = score.ToString();
	}
}
