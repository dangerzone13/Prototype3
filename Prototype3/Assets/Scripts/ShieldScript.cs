using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

	public static bool active;
	public GameObject shield;

	// Use this for initialization
	void Start () 
	{
		//shield = GameObject.FindGameObjectWithTag ("Shield");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			active = true;
			shield.SetActive (true);
		}

		if (Input.GetKeyUp (KeyCode.Mouse0)) 
		{
			active = false;
			shield.SetActive (false);
		}
	}
}
