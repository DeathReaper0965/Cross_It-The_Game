using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerLevel00 : MonoBehaviour {

	private Vector3 pos;
	public float moveSpeed = 5f;
	private float hor, ver;

	// Use this for initialization
	void Start () 
	{
		pos = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	}
}
