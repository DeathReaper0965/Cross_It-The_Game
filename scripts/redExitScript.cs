using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class redExitScript : MonoBehaviour {
	public GameObject player, music, stopper;
	private int count;
	private Text t;

	void Update(){
		count = player.GetComponent<Collectibles_score> ().count;
		t = player.GetComponent<Collectibles_score> ().winText;
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player" && count >=1) {
			SceneManager.LoadScene ("Level 00");
			Destroy (stopper);
			music.GetComponent<AudioSource> ().Stop();
		} else if (coll.gameObject.tag == "Player" && count < 10) {
			t.text = "Collect all the 10 spheres to advance to the next level";
			Debug.Log ("collision entered!");
		}
	}
}
