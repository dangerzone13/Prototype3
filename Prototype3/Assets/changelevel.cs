﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changelevel : MonoBehaviour {
    public int level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Application.LoadLevel(level);
        }
    }
}
