using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public bool isCountingDown;
	public int maxTime; //If counting up, this becomes a failsafe to prevent int overflow.
	public Text time;

	private bool _timerRunning;
	public bool TimerRunning {
		get { return _timerRunning; }
		set { _timerRunning = value; }
	}

	private float timer;
	private int minutes;
	private int seconds;
	private string niceTime;

	private bool isClockRunning;

	void Start () {
		if (isCountingDown){
			timer = maxTime;
		} else {
			timer = 0;
		}
		FormatTime();
	}

	private void FormatTime(){
		minutes = Mathf.FloorToInt(timer/60f);
		seconds = Mathf.FloorToInt(timer - minutes * 60);
		niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		time.text = niceTime;
	}

	private void CountUp(){
		if (timer < maxTime){
			timer += Time.deltaTime;
		} else {
			timer = maxTime;
		}
		FormatTime();
	}

	private void CountDown(){
		if (timer > 0){
			timer -= Time.deltaTime;
		} else {
			timer = 0;
			GameManager.Instance.TriggerGameOver();
		}
		FormatTime();
	}

	private IEnumerator RunClock(){
		while (TimerRunning){
			if (isCountingDown){
				CountDown();
			}
			else {
				CountUp();
			}
			yield return null;
		}
	}

	public void StartClock(){
		TimerRunning = true;
		StartCoroutine(RunClock());
	}

	public void StopClock(){
		TimerRunning = false;
	}

	public void ResetClock(){
		if (isCountingDown){
			timer = maxTime;
		} else {
			timer = 0;
		}
		FormatTime();
	}

}
