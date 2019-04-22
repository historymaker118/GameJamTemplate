using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	private bool isPromptShowing;
	private GameObject interactableObj;


	void Update(){
		if (isPromptShowing && Input.GetButtonDown("Interact") && interactableObj != null){
			interactableObj.GetComponent<Interaction>().DoTheThing();
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Interactable"){
			col.gameObject.GetComponent<Interaction>().ShowPrompt(true);
			interactableObj = col.gameObject;
			isPromptShowing = true;
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Interactable"){
			col.gameObject.GetComponent<Interaction>().ShowPrompt(false);
			interactableObj = null;
			isPromptShowing = false;
		}
	}
}
