using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour, ICollectable {

	public int scoreValue;

	public void DoTheThing(GameObject player){
		var playerState = player.GetComponent<PlayerState>();
		playerState.UpdateScore(scoreValue);
	}
}
