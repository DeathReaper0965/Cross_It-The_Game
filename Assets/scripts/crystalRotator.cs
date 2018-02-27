using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalRotator : MonoBehaviour {

	[SerializeField] private Transform hero_go;
	private float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(transform.position, hero_go.position);
		if (distance < 4f) {
			transform.Rotate (new Vector3 (20f * Time.deltaTime, 120f * Time.deltaTime, 0f));
		}

	}
}
