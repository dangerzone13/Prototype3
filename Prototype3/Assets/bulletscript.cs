using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(this.transform.forward * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
