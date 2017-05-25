using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStill : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    public GameObject spawnpoint;
    public GameObject powerbox;

    public Transform target;

    public float speed;


    public bool awake;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //set timer for shot intervals.
        anim = GetComponent<Animator>(); 
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
        if (awake == true)
        {
            //animate 
            anim.SetBool("awake",true);

            /*rotate to face player
            Vector3 targetDir = target.position - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            bullet.transform.rotation = Quaternion.LookRotation(newDir);*/
            Instantiate(bullet, spawnpoint.transform.position, spawnpoint.transform.rotation);
        }
        else
        {
            anim.SetBool("awake", false);
        }

    }
}