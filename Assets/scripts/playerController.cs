using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {

	private Animator anim;
	private Rigidbody player;
	public float jumpSpeed = 10f;
	public float runSpeed = 10f;
	public bool isRunning = false;
	public bool isGrounded = true;
	//public bool jump;
	private Transform cam;
	private Vector3 camForward;
	private Vector3 move;
	private Vector3 norm;
	private float turnAmount;
	private float forward;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isGrounded", isGrounded);
		player = GetComponent<Rigidbody> ();
		cam = Camera.main.transform;
	}

	void Update () {

	}

	void FixedUpdate(){

		float hor = CrossPlatformInputManager.GetAxis ("Horizontal");
		float ver = CrossPlatformInputManager.GetAxis ("Vertical");

		if (cam != null) {
			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1));
			move = ver * camForward + hor * cam.right;
		}

		Debug.Log ("Coordinates: " + move.x + " " + move.y + " " + move.z);
		movePlayer (move);

	}

	void movePlayer(Vector3 move){

		if (move.magnitude > 1f) {
			move.Normalize ();
		}
		move = transform.InverseTransformDirection (move);
		//checkGrounded ();
		move = Vector3.ProjectOnPlane (move, norm);
		turnAmount = Mathf.Atan2 (move.x, move.z);
		forward = move.z;
		Debug.Log ("forward: " + forward);
		transform.position += new Vector3(0, 0, forward*runSpeed*Time.deltaTime);
		ApplyRotation ();
		//AnimatorStateChange ();
	}

	void ApplyRotation(){
		//float turnSpeed = Mathf.Lerp (180, 360, 1f);
		transform.Rotate (0, turnAmount * 200f * Time.deltaTime, 0);
	}

	void AnimatorStateChange(){
		
	}

	void checkGrounded(){
		RaycastHit hit;
		//Debug.DrawRay (transform.position + (Vector3.up * 0.1f), Vector3.down * 0.2f, Color.red);
		if (Physics.Raycast (transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, 0.1f)) {
			isGrounded = true;
			norm = hit.normal;
			print (hit.collider.gameObject.name);
		} else {
			isGrounded = false;
			norm = Vector3.up;
		}

		anim.SetBool ("isGrounded", isGrounded);
		print (" " + isGrounded);
	}

	/*void OnCollisionEnter(Collision col){
		if (col.collider.gameObject.name.Contains ("ground") || col.collider.gameObject.name.Contains ("Plane")) {
			isGrounded = true;
			anim.SetBool ("isGrounded", isGrounded);
		}
	}

	void mobileInput(){

		if (Input.GetKey (KeyCode.W) && isGrounded) {
			isRunning = true;
			anim.SetBool ("isRunning", isRunning);
			this.transform.position += this.transform.forward * 10f * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.W)) {
			this.transform.position += this.transform.forward * 10f * Time.deltaTime;
		}else {
			isRunning = false;
			anim.SetBool ("isRunning", isRunning);
		}

		//RaycastHit hit;
		//Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if (Input.GetKeyDown (KeyCode.Space)) {
			isGrounded = false;
			anim.SetBool ("isGrounded", isGrounded);
			player.AddForce (new Vector3 (0f, jumpSpeed, 0f));
		} else if(!Physics.Raycast(transform.position, Vector3.down, out hit, 1f)){
			isGrounded = false;
			anim.SetBool ("isGrounded", isGrounded);
			//Debug.Log ("Collider found: " + hit.collider.gameObject.name);
		}

	} */
}
