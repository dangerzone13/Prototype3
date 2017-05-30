using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
    public float helth;
    public float dam;

    public bool ded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(helth <= 0)
        {
            ded = true;
            Application.Quit();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            helth -= dam;
        }
        if (collision.gameObject.tag == "instakill")
        {
            helth -= dam*2;
        }
    }

    }
