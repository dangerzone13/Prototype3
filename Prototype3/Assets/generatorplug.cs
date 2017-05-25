using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorplug : MonoBehaviour {

    public GameObject target;


    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "battery")
        {
            target.GetComponent<opendoorauto>().powered = true;
            Debug.Log("Bleh");
        }
    }
    void OnTriggerExit(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "battery")
        {
            target.GetComponent<opendoorauto>().powered = false;
            Debug.Log("Bleh");
        }
    }
}
