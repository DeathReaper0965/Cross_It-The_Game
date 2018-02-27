using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelMusic : MonoBehaviour {

	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
}
