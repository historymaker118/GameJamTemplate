using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public Image healthbar;
	public float healthMax;

	private float health;

	void Start () {
		health = healthMax;
	}

	public void UpdateHealth(float amount){
		health += amount;
		if (health >= healthMax){
			health = healthMax;
		}
		if (health <= 0){
			health = 0;
			GameManager.Instance.TriggerGameOver();
		}
		float healthPercent = health / healthMax;
		if (healthbar != null){
			healthbar.fillAmount = healthPercent;
		}
	}
}
