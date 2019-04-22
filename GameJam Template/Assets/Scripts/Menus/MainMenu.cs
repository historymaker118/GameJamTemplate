﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject titlecard;
	public GameObject loadMenu;
	public GameObject optionsMenu;
	public GameObject scoreboard;

	void Start () {
		if (titlecard != null){
			titlecard.SetActive(true);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(false);
		}
		if (scoreboard != null){
			scoreboard.SetActive(false);
		}
	}

	public void StartButton_Click(){
		SceneManager.LoadSceneAsync("Main");
	}

	public void LoadButton_Click(){
		if (titlecard != null){
			titlecard.SetActive(false);
		}
		if (loadMenu != null){
			loadMenu.SetActive(true);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(false);
		}
		if (scoreboard != null){
			scoreboard.SetActive(false);
		}
	}

	public void OptionsButton_Click(){
		if (titlecard != null){
			titlecard.SetActive(false);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(true);
		}
		if (scoreboard != null){
			scoreboard.SetActive(false);
		}
	}

	public void ScoreboardButton_Click(){
		if (titlecard != null){
			titlecard.SetActive(false);
		}
		if (loadMenu != null){
			loadMenu.SetActive(false);
		}
		if (optionsMenu != null){
			optionsMenu.SetActive(false);
		}
		if (scoreboard != null){
			scoreboard.SetActive(true);
		}
	}

	public void QuitButton_Click(){
		Application.Quit();
	}
}
