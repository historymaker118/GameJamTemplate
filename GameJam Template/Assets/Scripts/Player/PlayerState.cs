using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public Image healthbar;
	public float healthMax;
	public Text scoreText;
	public ScreenShake cameraShake;

	private int score;
	private float health;

	void Start () {
		health = healthMax;
		score = 0;
	}

	public void UpdateHealth(float amount){
		health += amount;
		if (health >= healthMax){
			health = healthMax;
		}
		if (health <= 0){
			health = 0;
		}
		float healthPercent = health / healthMax;
		if (healthbar != null){
			healthbar.fillAmount = healthPercent;
		}
	}

	public void UpdateScore (int amount){
		score += amount;
		if (scoreText != null){
			scoreText.text = score.ToString();
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag){
			case "Collectable":
				UpdateScore(10);
				Destroy(col.gameObject);
				break;
			case "Hazard":
				UpdateHealth(-25);
				StartCoroutine(cameraShake.Shake(0.25f, 0.5f));
				break;
		}
	}
}
