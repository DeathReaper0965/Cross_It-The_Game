using UnityEngine;
using System.Collections;

public class Scene3 : MonoBehaviour 
{
	public Material ocean_material;

	void Start () 
	{
		Ocean.gameObject.SetActive(true);	
		Ocean.gameObject.transform.position 					= new Vector3(0.0f, -50.0f, 0.0f);
		Ocean.gameObject.transform.localScale 					= Vector3.one * 1024.0f;
		Ocean.gameObject.isStatic = true;
		Ocean.gameObject.GetComponent<MeshRenderer> ().material = ocean_material;
	}


	void Update () 
	{
		Ocean.AdjustPitch();
		Ocean.SetSoundPositionRelativeToViewer();
	}
}