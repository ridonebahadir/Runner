using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Spawn")
        {
            Debug.Log("Engel Deðdi");
            gameObject.SetActive(false);
        }
    }
}
