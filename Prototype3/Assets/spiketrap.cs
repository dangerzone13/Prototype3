using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiketrap : MonoBehaviour {

    public Rigidbody Player;
    public float backforce;
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
        // lift spike trap
        if (other.gameObject.tag == "Player")
        {

            anim.SetBool("triggered", true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Shield")
        {
            Player.AddForce(Vector3.back * backforce, ForceMode.Acceleration);
            Debug.Log("shiiiiiield");
        }
    }
}
