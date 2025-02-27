using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombStrength : MonoBehaviour
{
    private CharacterController player;

    private bool hitted = false;
    private float timer;
    
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }
    
    private void FixedUpdate() {

        if (hitted)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            player.Move((Vector3.back + Vector3.up * 2.5f) * Time.deltaTime / timer);
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
            Debug.Log("esplosione");
            Vector3 pointOfContact = player.transform.position;
            Vector3 pointAfterContact = player.transform.position - Vector3.back;
            hitted = true;
        }
    }

}