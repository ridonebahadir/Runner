using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFixed : MonoBehaviour
{
    public Spawn spawn;
    public static int value;
    void Start()
    {
        if (value==1)
        {
            spawn.enabled = true;
        }
       
    }

    // Update is called once per frame
    public void StartButton()
    {
        value = 1;
        spawn.enabled = true;
    }
}
