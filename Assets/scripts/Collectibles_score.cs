using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectibles_score : MonoBehaviour {

	public Text scoreText;
	public int count = 0;
	private float t;
	public Text winText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + count;
	}

	void Update(){
		if (count >= 10) {
			winText.text = "Congrats! Advance to the arch to proceed to next level.";
			count = -10;
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "collectible") {
			coll.gameObject.SetActive (false);
			count++;
			scoreText.text = "Score: " + count;
		}
	}
}
