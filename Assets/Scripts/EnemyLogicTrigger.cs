using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyLogicTrigger : MonoBehaviour
{
    public int currentWaypointIndex;
    GameObject enemy;

    private float degreesPerSecond = 100.0f;
    private float speed = 2.0f;

    public GameObject[] waypoints;
    
    GameObject player;

    float chasingSpeed = 6.0f;

    private bool isChasing = false;


    private void OnEnable()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    private void Start()
    {
        player = GameObject.Find("ThirdPersonPlayer");
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        
        
        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chasingSpeed * Time.deltaTime);
        }
        else
        {
            Movement();
        }
        
    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Contains("ThirdPersonPlayer"))
        {
            Debug.Log("Ti vedo");
            isChasing = true;
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Contains("ThirdPersonPlayer"))
        {
            Debug.Log("non ti vedo più");
            isChasing = false;
        }
    }
    
    
    private void Movement()
    {
        if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 1)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; 
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime, Space.Self);
        }

    }
        
}
