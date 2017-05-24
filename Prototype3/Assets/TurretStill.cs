using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStill : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    public GameObject powerbox;

    public bool awake;

    // Use this for initialization
    void Start()
    {
        //set timer for shot intervals.
    }

    void OnTriggerEnter(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "Player")
        {
            awake = true;
            Debug.Log("Bleh");
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if the player leaves the turret collider : set turret to be asleep
        if (other.gameObject.tag == "Player")
        {
            awake = false;
            Debug.Log("Bleeeeh");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if the turret is awake
        count down four seconds
        instantiate 1 projectile with forward momentum.
        reset count down after each shot

        if moving turrate: find player. set objects angle to face player everyframe.*/


    }
}