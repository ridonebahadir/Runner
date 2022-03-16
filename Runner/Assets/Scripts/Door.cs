using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Sprite[] icons;

    //public SpriteRenderer rDoorIcon;
    //public SpriteRenderer lDoorIcon;

    public Image rDoorIcon;
    public Image lDoorIcon;
    public string[] coinName;


    public TextMeshPro coinNameR;
    public TextMeshPro coinNameL;
    public int randomR;
    public int randomL;
    void Start()
    {
        randomR = Random.Range(0, icons.Length);
        rDoorIcon.sprite = icons[randomR];

        coinNameR.text = coinName[randomR];



        randomL = Random.Range(0, icons.Length);

        if (randomL== randomR)
        {
            randomL += 1;
        }
        else
        {
          
            lDoorIcon.sprite = icons[randomL];
            coinNameL.text = coinName[randomL];
        }
      

    }

  
}
