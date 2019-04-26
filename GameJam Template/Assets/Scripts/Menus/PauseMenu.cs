using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Animator transition;
	public GameObject pauseUI;
	public GameObject optionsMenu;

	private bool isMenuShowing;

	void Start(){
		pauseUI.SetActive(false);
		isMenuShowing = false;
	}

	void Update(){
		if (Input.GetButtonDown("Cancel")){
			isMenuShowing = !isMenuShowing;
			GameManager.Instance.PauseGame(isMenuShowing);
			pauseUI.SetActive(isMenuShowing);
			if (!isMenuShowing){
				optionsMenu.SetActive(false);
			}
		}
	}

	public void OptionsMenu(){
		optionsMenu.SetActive(!optionsMenu.activeSelf);
	}

	public void QuitToMenu(){
		StartCoroutine(transitionScene(2f));
	}

	public void QuitToDesktop(){
		Application.Quit();
	}

	private IEnumerator transitionScene(float duration){
		transition.SetTrigger("FadeOut");
		float elapsed = 0;
		while (elapsed < duration){
			elapsed += Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadSceneAsync("Menu");
	}

}
