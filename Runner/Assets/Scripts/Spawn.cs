using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn : MonoBehaviour
{
    public PlayerMove playerMove;
    public Player player;
    public GameObject[] engel;
    public GameObject[] money;
    //public GameObject[] coin;
    public GameObject door;
    //public List<int> coinCount = new List<int>();

    public GameObject Throw;
    public GameObject seviye;
    public GameObject endObj;
    
    public Transform environment;
    public Transform ThrowParent;
    public Transform Coins;
    [Range(0,10)]
    public float spawnTime;
    public int counterEngel;
    public int toplamEngel;


    [Header("ThrowColor")]
    public Color[] color;
    [Header("Camera")]
    public Animator StartCameraAnim;
    public AnimationClip CameraStartMove;
    public GameObject mainCamera;
    public GameObject startCamera;
    public GameManager gm;
    public float time;
    public static int value;
    public GameObject startIcon;
    private void Awake()
    {
        playerMove.enabled = false;
       
    }
    private void Start()
    {
        StartCoroutine(SpawnStart());
        StartCoroutine(FogSettings());

        if (value == 1)
        {
            
            mainCamera.SetActive(true);
            startCamera.SetActive(false);
            playerMove.enabled = true;
        }
        else
        {
            value = 1;
            StartCoroutine(MoveCamera());
            EventSystem.current.currentSelectedGameObject.SetActive(false);
            playerMove.enabled = true;
        }
    }
   
   

    public void ComeBackCamera()
    {
      
        startCamera.transform.position = mainCamera.transform.position;
        mainCamera.SetActive(false);
        startCamera.SetActive(true);
        StartCameraAnim.SetBool("ComeBack",true);
        Invoke("Restart", 5);
    }
    void Restart()
    {
        gm.Restart();
    }
    IEnumerator FogSettings()
    {
        float time = CameraStartMove.length; 
        float passTime = 0f;

        float currentStart = RenderSettings.fogStartDistance;
        float targetStart = 50;

        float currentEnd = RenderSettings.fogEndDistance;
        float targetEnd = 250;

        while (passTime < time) 
        {
            passTime += Time.deltaTime;
            RenderSettings.fogStartDistance = Mathf.Lerp(1000, 50, passTime / time);
            RenderSettings.fogEndDistance = Mathf.Lerp(7000, 250, passTime / time); 

            yield return null;
        }


        currentStart = targetStart;
        currentEnd = targetEnd;
    }
    IEnumerator MoveCamera()
    {

        StartCameraAnim.SetBool("CameraStartMove", true);
        RenderSettings.fogStartDistance = 50;
        RenderSettings.fogEndDistance = 250;
       yield return new WaitForSeconds(CameraStartMove.length);
        mainCamera.SetActive(true);
        startCamera.SetActive(false);
        startIcon.SetActive(false);
    }
    bool run = true;
    public void SpawnEngel()
    {
        run = true;
        //toplamEngel = 0;
        counterEngel = 0;
        StartCoroutine(SpawnStart());
        //StartCoroutine(SpawnCoinStart());
       
    }
    public static bool finish;
   
   IEnumerator SpawnStart()
    {
       
        while (run)
            {
            //counterEngel++;
            if (finish)
            {
                run = false;
                moneyRandom = true;
                SpawnMoney();
                yield return new WaitForSeconds(spawnTime);
                SpawnThrow();


                StopCoroutine(SpawnStart());
                GameManager.wait = false;
                finish = false;
               
                
               
            }
            else
            {
                SpawnMoney();
              
                yield return new WaitForSeconds(spawnTime+1);
                int random = UnityEngine.Random.Range(0, engel.Length);
                //float x = UnityEngine.Random.Range(0.0F, 1.0F) < 0.5F ? -170f : -160f;
                Instantiate(engel[random], transform.position, Quaternion.identity, environment);
               
                yield return new WaitForSeconds(spawnTime);
                SpawnCoinStart();
                yield return new WaitForSeconds(spawnTime);
            }
           
           
           
            //yield return new WaitForSeconds(spawnTime);
           
        }
           
        
       
    }

    bool throww;
    int count;
   
    void SpawnThrow()
    {
        throww = true;
        count = 0;
        Instantiate(endObj, transform.position, Quaternion.Euler(0, 180, 0), environment);
        StartCoroutine(ThrowTime());
    }
    IEnumerator ThrowTime()
    {
        while (throww)
        {
           
            yield return new WaitForSeconds(0.25f);
           
            count++;
            if (count>7)
            {
                GameObject objThrow=Instantiate(Throw, transform.position, Quaternion.Euler(0,180,0), ThrowParent);
                objThrow.transform.GetChild(0).GetComponent<TextMeshPro>().text = count.ToString() + " x";
                objThrow.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = color[count];


               
              

            }
            else
            {
                GameObject obj = Instantiate(seviye, transform.position, Quaternion.Euler(0, 180, 0), ThrowParent);
                obj.transform.GetChild(0).GetComponent<TextMeshPro>().text = count.ToString() + " x";
                obj.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = color[count];
            }
            if (count == 10)
            {
              

                throww = false;

            }
        }
    }
    int randomMoneyPrefab;
    public bool moneyRandom;
    void SpawnMoney()
    {

        para = true;
        tane = 0;
       
        randomMoneyPrefab = UnityEngine.Random.Range(0, money.Length);
        int uzunluk = UnityEngine.Random.Range(4, 7);
        StartCoroutine(MoneyBasma(randomMoneyPrefab,uzunluk));

    }

    int add = 2;

    bool para = true;
    int tane;
    IEnumerator MoneyBasma(int random,int uzunluk)
    {
        if (moneyRandom)
        {
            while (para)
            {
                yield return new WaitForSeconds(0.25f);
                int x = UnityEngine.Random.Range(0, money.Length);
                Instantiate(money[x], transform.position + new Vector3(-6, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                int y = UnityEngine.Random.Range(0, money.Length);
                Instantiate(money[y], transform.position + new Vector3(0, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                int z = UnityEngine.Random.Range(0, money.Length);
                Instantiate(money[z], transform.position + new Vector3(6, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                tane++;

                if (tane == uzunluk)
                {

                    para = false;
                    moneyRandom = false;
                }
            }
        }
        else
        {
            while (para)
            {
                yield return new WaitForSeconds(0.25f);

                Instantiate(money[random], transform.position + new Vector3(-6, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                Instantiate(money[random], transform.position + new Vector3(0, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                Instantiate(money[random], transform.position + new Vector3(6, 2, 0), Quaternion.Euler(0, 90, 0), environment);
                tane++;

                if (tane == uzunluk)
                {

                    para = false;
                }
            }
        }
       
        
    }


    void SpawnCoinStart()
    {

        add++;
        Instantiate(door, transform.position + new Vector3(0, 5, 0), Quaternion.identity, Coins);
      
    }

    private void Update()
    {
        Debug.Log("Finish = "+finish);
    }

}
