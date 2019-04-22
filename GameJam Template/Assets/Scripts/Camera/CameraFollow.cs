using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	//must be between 0 and 1
	[Range(0, 1)]
	public float smoothSpeed = 0.125f;
	public bool hasSmoothing;
	public Vector3 offset;

	void LateUpdate(){
		Vector3 desiredPosition = target.position + offset;
		if (hasSmoothing){
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
			transform.position = smoothedPosition;
			transform.LookAt(target);
		} else {
			transform.position = desiredPosition;
		}
	}
}
