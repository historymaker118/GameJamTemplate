using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Animator transition;

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
