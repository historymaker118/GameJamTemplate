using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;

	public List<AudioSource> audioSources;

	void Awake(){
		if (Instance == null){
			Instance = this;
			DontDestroyOnLoad(this);
		} else {
			GameObject.Destroy(this);
		}
	}

	void OnDestroy(){
		foreach (AudioSource audio in audioSources){
			audio.Stop();
		}
	}
}
