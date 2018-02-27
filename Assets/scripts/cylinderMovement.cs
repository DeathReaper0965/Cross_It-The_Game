using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderMovement : MonoBehaviour {

	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("collision occured!");
			coll.gameObject.transform.parent = this.transform;
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.parent = null;
			Debug.Log ("trigger exited");
		}
	}
}
