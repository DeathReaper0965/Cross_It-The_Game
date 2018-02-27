using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchRotation : MonoBehaviour {

	public GameObject player_go;
	private Touch initialTouch = new Touch();
	public GameObject joyStick;

	private Vector3 origRot;
	private float rotY;
	public int dir = -1;
	public float rotSpeed = 0.5f;
	private Vector3 oldPos, newPos;

	// Use this for initialization
	void Start () {
		origRot = player_go.transform.eulerAngles;
		oldPos = player_go.transform.position;
		rotY = origRot.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		newPos = player_go.transform.position;
		if (newPos == oldPos) {
			
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Began && !touch.Equals (joyStick)) {
					initialTouch = touch;

				} else if (touch.phase == TouchPhase.Moved && !touch.Equals (joyStick)) {
					float deltaY = initialTouch.position.x - touch.position.x;
					rotY += deltaY * Time.deltaTime * rotSpeed * dir;
					player_go.transform.eulerAngles = new Vector3 (0f, rotY, 0f);

				} else if (touch.phase == TouchPhase.Ended && !touch.Equals (joyStick)) {
					initialTouch = new Touch ();

				}
			}
		} else {
			oldPos = newPos;
		}
	}
}
