using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : MonoBehaviour, IInteractable {

	public GameObject prompt;
	public GameObject dialog;

	void Start(){
		prompt.SetActive(false);
		dialog.SetActive(false);
	}

	public void ShowPrompt(bool showing){
		prompt.SetActive(showing);
	}

	public void DoTheThing(){
		StartCoroutine(ShowDialog(2f));
	}

	private IEnumerator ShowDialog(float time){
		dialog.SetActive(true);
		float elapsed = 0;
		while(elapsed < time){
			elapsed += Time.deltaTime;
			yield return null;
		}
		dialog.SetActive(false);
	}
}
