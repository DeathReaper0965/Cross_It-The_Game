using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMovement : MonoBehaviour {

	private Vector3 platform;
	public float moveSpeed = 0.3f;
	public GameObject base1;
	public GameObject base2;
	public float collDist = 30f;

	// Use this for initialization
	void Start () 
	{
		platform = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		platform = platform + new Vector3 (moveSpeed * Time.deltaTime, 0f, 0f);
		platform = Vector3.Lerp (transform.position, platform, 1f);
		transform.position = platform;
		//Vector3 distance = base1.transform.position - base2.transform.position;
		if(Vector3.Distance(transform.position, base1.transform.position) <= collDist || Vector3.Distance(transform.position, base2.transform.position) <= collDist)
		{
			moveSpeed = -moveSpeed;
		}
	}


}