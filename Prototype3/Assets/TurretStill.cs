using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStill : MonoBehaviour
{

    public GameObject bullet;
    public GameObject player;
    public GameObject spawnpoint;
    public GameObject splode;
    public GameObject splode2;




    public float spawntime;


    public bool awake;
    private Animator anim;
    private bool ded = false;
    //private Coroutine Spawn; 

    // Use this for initialization
    void Start()
    {
        //set animation component
        anim = GetComponent<Animator>();
        //set timer for shot intervals.
        InvokeRepeating("Spawn", spawntime, spawntime);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the player is inside the turret collider : set the turret to be awake
        if (other.gameObject.tag == "Player" && ded == false)
        {
            awake = true;
            Debug.Log("Bleh");
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if the player leaves the turret collider : set turret to be asleep
        if (other.gameObject.tag == "Player" && ded == false)
        {
            awake = false;
            Debug.Log("Bleeeeh");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bulletdef" && ded == false && awake == true)
        {
            Instantiate(splode2, spawnpoint.transform.position, splode2.transform.rotation);
            DestroyObject(bullet);
            ded = true;
            anim.SetBool("awake", false);
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
        if (awake == true && ded == false)
        {
            //animate 
            anim.SetBool("awake",true);

            /*rotate to face player
            Vector3 targetDir = target.position - transform.position;
            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            bullet.transform.rotation = Quaternion.LookRotation(newDir);*/
  
        }
        else
        {
            //animate down
            gameObject.GetComponent<Animator>().enabled = true;
            anim.SetBool("awake", false);
        }

    }
    void Spawn()
    {
        if (awake == true && ded == false)
        {
            //shoot bullet
            Instantiate(bullet, spawnpoint.transform.position, spawnpoint.transform.rotation);
            Instantiate(splode, spawnpoint.transform.position, splode.transform.rotation);
        }
      
    }
    void animateoff()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

}