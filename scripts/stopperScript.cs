using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopperScript : MonoBehaviour {

	public GameObject playerGo;

	void OnCollisionEnter(Collision coll){
		if (playerGo.GetComponent<Collectibles_score> ().count >= 10) {
			Destroy (this.gameObject);
		}
	}
}
