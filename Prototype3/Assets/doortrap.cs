using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortrap : MonoBehaviour {
    public float maxpos;
    public float minpos;
    public float speed;

    private bool stop;
    private bool open;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (open = true && transform.position.x < 0)
        {
            transform.position.x -= speed;
        }
	}
}
