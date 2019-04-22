using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float rotateSpeed;

	void Update () {
		transform.Rotate(0, rotateSpeed, 0);
	}
}
