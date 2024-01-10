using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionSet;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("ThirdPersonPlayer"))
        {
            Debug.Log("Esplodo");
            Instantiate(explosionSet, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosionSet);
        }
    }
}
