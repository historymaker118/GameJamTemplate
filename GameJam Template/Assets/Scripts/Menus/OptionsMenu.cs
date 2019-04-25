using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer mixer;
	public Dropdown resolutionDropdown;

	private Resolution[] resolutions;

	void Start(){
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();
		
		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i=0; i < resolutions.Length; i++){
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetVolumeMusic(float value){
		mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
	}

	public void SetVolumeEffects(float value){
		mixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
	}

	public void SetVolumeAmbient(float value){
		mixer.SetFloat("AmbienceVolume", Mathf.Log10(value) * 20);
	}

	public void SetQuality(int qualityIndex){
		QualitySettings.SetQualityLevel(4 - qualityIndex);
	}

	public void SetFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
	}

	public void SetResolution(int resolutionIndex){
		Resolution res = resolutions[resolutionIndex];
		Screen.SetResolution(res.width, res.height, Screen.fullScreen);
	}
}
