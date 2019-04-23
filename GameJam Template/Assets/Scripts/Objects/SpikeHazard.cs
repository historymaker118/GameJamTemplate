using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazard : MonoBehaviour, IHazard{

	public int damageAmount;
	public ScreenShake cameraShake;
	public float screenshakeDuration;
	public float screenshakeMagnitude;

	public void DoTheThing(GameObject player){
		var playerState = player.GetComponent<PlayerState>();
		playerState.UpdateHealth(-damageAmount);
		StartCoroutine(cameraShake.Shake(screenshakeDuration, screenshakeMagnitude));
	}
}
