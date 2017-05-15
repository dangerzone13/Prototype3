using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	public bool active;
	public GameObject shield;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			active = true;
			shield.SetActive (true);
		}

		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			active = false;
			shield.SetActive (false);
		}
	}
}
