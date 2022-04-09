using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    public Coin[] coin;

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
    int maxRange = 10;

    private void Awake()
    {
        if (Player.level % 3 == 2)
        {
            maxRange += 5;

        }
        int value = Random.Range(0, 2);

        if (value == 1)
        {
            coin[value].random = Random.Range(5, maxRange);
            coin[value - 1].random = Random.Range(-5, -maxRange);
        }
        else
        {
            coin[value].random = Random.Range(1, 10);
            coin[value + 1].random = Random.Range(-1, -10);
        }
    }

    void Start()
    {
       
        



        randomR = Random.Range(0, icons.Length);
        rDoorIcon.sprite = icons[randomR];

        coinNameR.text = icons[randomR].name;



        randomL = Random.Range(0, icons.Length);

        if (randomL== randomR)
        {
            if (randomR==icons.Length-1)
            {
                randomL = 0;
                lDoorIcon.sprite = icons[randomL];
                coinNameL.text = icons[randomL].name;
            }
            
        }
        else
        {
          
            lDoorIcon.sprite = icons[randomL];
            coinNameL.text = icons[randomL].name;
        }
      

    }

  
}
