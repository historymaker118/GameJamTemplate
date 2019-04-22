using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public void QuitToMenu(){
		SceneManager.LoadSceneAsync("Menu");
	}

	public void QuitToDesktop(){
		Application.Quit();
	}

}
