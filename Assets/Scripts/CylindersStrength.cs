using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CylinderStrength : MonoBehaviour
{
    private CharacterController player;
    private bool playerObj;

    private bool hitted = false;
    private float timer;

    private bool alive;
    
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }
    
    private void FixedUpdate() {
        
        //playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>().alive;
        
        //alive = playerObj.GetComponent<ThirdPersonMovement>().alive;

        
        if (hitted)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            
            
            player.Move((Vector3.left + Vector3.up)*2 * Time.deltaTime / timer);
            if (timer >= 1)
            {
                hitted = false;
                timer = 0;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("ThirdPersonPlayer") && !hitted) 
        {
            Debug.Log("contatto");
            Vector3 pointOfContact = player.transform.position;
            Vector3 pointAfterContact = player.transform.position - Vector3.left;
            hitted = true;
        }
    }

}