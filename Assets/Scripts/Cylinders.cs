using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour
{ 
    public GameObject cylinder;
    float potenza = 5;
    float reload = 2f;
    
    
    void Start()
    {
    }

    void Update()
    {
        if (Time.time >= reload)
        {
            cylinder = Instantiate(cylinder, new Vector3(8, 3, 9) + Vector3.left, Quaternion.Euler(270, 0, 0));
            cylinder.GetComponent<Rigidbody>().velocity = Vector3.left  * this.potenza;
            reload = Time.time + 2f;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinalLayer"))
        {
            Destroy(this.gameObject);
        }
    }
}


