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

    private GameObject wp1, wp2;
    public GameObject[] waypoints;
    
    GameObject player;

    Rigidbody rb;
    float walkingSpeed = 5.0f;

    private bool isChasing = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        player = GameObject.Find("ThirdPersonPlayer");
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

    }
    
    void Update()
    {
        
        if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, enemy.transform.position) < 1)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; 
            }
        }
        else
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
        
        if (isChasing)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * walkingSpeed * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, enemy.transform.position) < 1)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0; 
                }
            }
            else
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            }
            enemy.transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime, Space.Self);
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
}
