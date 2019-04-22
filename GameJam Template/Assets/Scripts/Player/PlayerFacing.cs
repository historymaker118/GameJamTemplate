using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour {

	public Transform model;
	public Transform cameraTarget;
	public float cameraOffset;

	private bool lastFacingRight;
	private float smoothSpeed;
	private Vector3 cameraTargetPos;
	private Vector3 cameraCurrentPos;


	// Update is called once per frame
	void Update () {
		if (!GameManager.Instance.IsGameRunning){
			return;
		}
		if (Input.GetAxis("Horizontal") < 0){ //Facing Left
			model.rotation = Quaternion.Euler(0, -90, 0);
			lastFacingRight = false;
			cameraTargetPos = new Vector3(-cameraOffset, 0.5f, 0);
			smoothSpeed = 5f;
		} else if (Input.GetAxis("Horizontal") > 0){ //Facing Right
			model.rotation = Quaternion.Euler(0, 90, 0);
			lastFacingRight = true;
			cameraTargetPos = new Vector3(cameraOffset, 0.5f, 0);
			smoothSpeed = 5f;
		} else { //Face last position
			if (lastFacingRight){
				model.rotation = Quaternion.Euler(0, 145, 0);
				cameraTargetPos = new Vector3(0, 0.5f, 0);
				smoothSpeed = 1f;
			} else {
				model.rotation = Quaternion.Euler(0, -145, 0);
				cameraTargetPos = new Vector3(0, 0.5f, 0);
				smoothSpeed = 1f;
			}
		}
		cameraCurrentPos = Vector3.MoveTowards(cameraCurrentPos, cameraTargetPos, smoothSpeed * Time.deltaTime);
		cameraTarget.position = cameraCurrentPos + model.position;
	}
}
