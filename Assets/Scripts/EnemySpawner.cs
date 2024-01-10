using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;

    GameObject enemy;
    
    void Start()
    {
        enemy = Instantiate(enemyObject, new Vector3(16, 3.5f, 9), Quaternion.Euler(0, 0, 0));
    }
    
    void Update()
    {

    }

    
}
