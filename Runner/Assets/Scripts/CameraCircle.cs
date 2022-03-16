using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCircle : MonoBehaviour
{
    float timeCounter;

    float speed;
    public float timer;
    public Transform target;
   
    void Start()
    {
        speed = 80;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer<4.5f)
        {
           
            Debug.Log("Timer = " + timer);
            transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        
    }
}
