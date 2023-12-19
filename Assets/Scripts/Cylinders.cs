using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour
{
    [SerializeField] private GameObject cylinderObject;
    public List<GameObject> cylinders = new List<GameObject>();
    
    private float tempo = 0;
    public float potenza = 5;

    void Start()
    {
        cylinders = new List<GameObject>();
    }

    void Update()
    {
        Invoke("SpawnCylinder", 2f);
    }

    void SpawnCylinder()
    {
        var tmp = Instantiate(cylinderObject, new Vector3(8, 3, 9), Quaternion.Euler(270, 0, 0));
        tmp.GetComponent<Rigidbody>().velocity =  Vector3.forward * this.potenza;
        cylinders.Add((tmp));
    }
}
