using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3f;
	public float jumpVelocity = 3f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	public float jumpMemory = 0;
	public float jumpMemoryTime = 0.2f;
	public float groundedMemory = 0;
	public float groundedMemoryTime = 0.25f;

	public float horizontalAcceleration = 1;
	[Range(0, 1)]
	public float horizontalDampingBasic = 0.5f;
	[Range(0, 1)]
	public float horizontalDampingStopping = 0.5f;
	[Range(0, 1)]
	public float horizontalDampingTurning = 0.5f;

	private bool isGrounded;
	private Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {

	}

	void Update () {
		if (!GameManager.Instance.IsGameRunning){
			return;
		}
		groundedMemory -= Time.deltaTime;
		if (isGrounded){
			groundedMemory = groundedMemoryTime;
		}

		jumpMemory -= Time.deltaTime;
		if (Input.GetButtonDown("Jump")){
			jumpMemory = jumpMemoryTime;
		}

		rb.velocity = new Vector2 (Input.GetAxis("Horizontal") * speed, rb.velocity.y);

		if ((jumpMemory > 0) && (groundedMemory > 0)){
			jumpMemory = 0;
			groundedMemory = 0;
			rb.velocity += Vector2.up * jumpVelocity;
		}
		if (rb.velocity.y < 0){
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		float horizontalVelocity = rb.velocity.x;
		horizontalVelocity += Input.GetAxisRaw("Horizontal");

		if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f){
			horizontalVelocity *= Mathf.Pow(1f - horizontalDampingStopping, Time.deltaTime * 10f);
		} else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity)) {
			horizontalVelocity *= Mathf.Pow(1f - horizontalDampingTurning, Time.deltaTime * 10f);
		} else {
			horizontalVelocity *= Mathf.Pow(1f - horizontalDampingBasic, Time.deltaTime * 10f);
		}

		rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D col){
		isGrounded = true;
	}

	void OnCollisionExit2D(Collision2D col){
		isGrounded = false;
	}
}
