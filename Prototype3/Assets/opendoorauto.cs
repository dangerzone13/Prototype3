using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoorauto : MonoBehaviour {

    public bool powered;
    private Animator anim;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "Player" && powered == true)
        {
            anim.SetBool("open", true);
            Debug.Log("Bleh");
        }
    }
    void OnTriggerExit(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "Player" && powered == true)
        {
            anim.SetBool("open", false);
            Debug.Log("Bleh");
        }
    }
    void OnTriggerStay(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "Player" && powered == true)
        {
            anim.SetBool("open", true);
            Debug.Log("Bleh");
        }
    }
}
