using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretrotationy : MonoBehaviour
{


     private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        //newposx = transform.position.x * 0.5;
    }

    void Update()
    {
        targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        targetRotation = (Quaternion.LookRotation(targetPoint, Vector3.forward)); // Quaternion.Euler(0, 75, 0));
        transform.rotation = (Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f));
    }
}