using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [Header("COIN VALUE")]

    //BTC
    public Transform Arrows;
   
    //public Text btcValueText;
    public GameObject bombParticle;
    //public GameObject coinParticleRise;
    //public GameObject coinParticleDown;
    //private Material material;
   
    public TextMeshPro valueText;
    public MeshRenderer Pervaz;
    public Material doormaterialGreen;
    public Material doormaterialRed;
    //public TextMeshPro coinName;
    ////ETH
    //public Transform ethOk;
    //public int eth;
    //public Text ethValueText;

    public int random;
    int maxRange = 10;
    int minRange = 0;
    

    private void Start()
    {
        //material =transform.GetChild(0).GetComponent<Renderer>().material;
        if (Player.level % 3 == 2)
        {
            maxRange += 5;
            minRange -= 5;
        }
        CoinBorsa();
        
    }
    void CoinBorsa()
    {
       
            
             random = UnityEngine.Random.Range(minRange, maxRange);
             if (random == 0)
            {
            //Pervaz.material.color = Color.white;
            //valueText.text = "%" + random.ToString();
            //Arrows.transform.GetChild(0).gameObject.SetActive(false);
            //Arrows.transform.GetChild(1).gameObject.SetActive(false);
            //Arrows.transform.GetChild(2).gameObject.SetActive(true);
            random = 5 ;
             }
            if (random > 0)
            {

            valueText.text = "%" + (Math.Abs(random)).ToString();
            Pervaz.material = doormaterialGreen;
             riseOrDown = 1;
            Arrows.transform.GetChild(0).gameObject.SetActive(true);
            Arrows.transform.GetChild(1).gameObject.SetActive(false);
            Arrows.transform.GetChild(2).gameObject.SetActive(false);
             }
           
      
            if (random < 0)
            {
                valueText.text ="-"+"%"+ (Math.Abs(random)).ToString();
            Pervaz.material = doormaterialRed;
                riseOrDown = 2;
            Arrows.transform.GetChild(0).gameObject.SetActive(false);
            Arrows.transform.GetChild(1).gameObject.SetActive(true);
            Arrows.transform.GetChild(2).gameObject.SetActive(false);
        }
           

            //yield return new WaitForSeconds(1.5f);

           
        






    }

    int riseOrDown;
    int deger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human")
        {
            deger= (Player.score * (Math.Abs(random))) / 100;
            if (random>0)
            {
                Player.score += deger;
                Debug.Log("deger + = "+deger);

                SoundManagerSfx.PlaySfx("DoorUpMoney");
            }
            if (random<0)
            {
                Debug.Log("deger - = " + deger);
                SoundManagerSfx.PlaySfx("DoorDownMoney");
                Player.score -= deger;
            }
            Player.counter = true;
            //bombParticle.GetComponent<Renderer>().material = material;
            //coinParticle.GetComponent<Renderer>().material = material;
            Instantiate(bombParticle, other.transform.position, Quaternion.identity);
            //switch (riseOrDown)
            //{
            //    case 1:
            //        Instantiate(coinParticleRise, other.transform.position, Quaternion.identity, transform.parent);
            //        break;
            //    case 2:
            //        Instantiate(coinParticleDown, other.transform.position, Quaternion.identity, transform.parent);
            //        break;
               
            //}
            
            gameObject.SetActive(false);
            valueText.gameObject.SetActive(false);
            GameManager.sira += 2;
        }
    }
}
