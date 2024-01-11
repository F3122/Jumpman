using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject bombObject;

    GameObject enemy;
    GameObject bomb;
    
    void Start()
    {
        bomb = Instantiate(bombObject, new Vector3(6.5f,2.9f,3.2f), Quaternion.Euler(0, 0, 0));
        bomb = Instantiate(bombObject, new Vector3(9.4f,2.9f,4.1f), Quaternion.Euler(0, 0, 0));
        bomb = Instantiate(bombObject, new Vector3(12.9f,2.9f,4.8f), Quaternion.Euler(0, 0, 0));
        
        enemy = Instantiate(enemyObject, new Vector3(16, 3.5f, 9), Quaternion.Euler(0, 0, 0));
    }
    
    void Update()
    {

    }

    
}
