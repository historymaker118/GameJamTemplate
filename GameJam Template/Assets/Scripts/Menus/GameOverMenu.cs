using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public Animator transition;

	public void StartAgain(){
		StartCoroutine(transitionScene(2f, "Main"));
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
