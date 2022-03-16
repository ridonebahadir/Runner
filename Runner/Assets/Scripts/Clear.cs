using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Spawn.finish = true;

        if (other.gameObject.tag=="Door")
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
