using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

	//public Transform player;
	Vector3 startPos;
	Quaternion startRot;

	void OnStart(){
		startPos = transform.position;
		startRot = transform.rotation;
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "death") {
			Debug.Log ("entered");
			transform.position = startPos;
			transform.rotation = startRot;
		}
	}
}
