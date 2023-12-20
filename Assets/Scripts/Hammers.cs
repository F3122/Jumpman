using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DA MODIFICARE, SCRIPT UPDATE NEL PREFAB


public class RotativeObstacles : MonoBehaviour
{
    public GameObject hammerObject;
    
    GameObject hammer1;
    GameObject hammer2;
    
    public float degreesPerSecond = 200.0f;

    private Vector3 hammerScale = new Vector3(10, 10, 10);
    
    void Start()
    {
        hammer1 = Instantiate(hammerObject, new Vector3(12, 4.5f, 6.5f),Quaternion.Euler(0, 30, -90));
        hammer2 = Instantiate(hammerObject, new Vector3(0, 3.5f, 3), Quaternion.Euler(0, 0, 270));
        hammer1.transform.localScale = hammerScale;
        hammer2.transform.localScale = hammerScale;
    }

    void LateUpdate()
    {
        hammer1.transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime, Space.Self); 
        //hammer1.transform.Rotate(Vector3.left * degreesPerSecond * Time.deltaTime,Space.Self);   
        
        hammer2.transform.Rotate(Vector3.up * degreesPerSecond * Time.deltaTime, Space.Self); 
        //hammer2.transform.Rotate(Vector3.left * degreesPerSecond * Time.deltaTime,Space.Self); 
    }
}
