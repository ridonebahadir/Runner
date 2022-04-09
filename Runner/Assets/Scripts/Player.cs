using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltimateCameraController.Cameras.Controllers;
using System.Collections.Generic;
//using FIMSpace.FSpine;
public class Player : MonoBehaviour
{


    public GameObject dolarFlow;
    public GameObject confetti;
    public CameraController cameraController;
    public CameraCircle cameraCircle;
    

    public GameManager gameManager;
    public Spawn spawn;
    public Transform rightBorder;
    public Transform leftBorder;
    public float speed;
    public float JumpForce;
    public float fallMultilier;
    Rigidbody rb;
    Animator anim;
    BoxCollider boxCollider;
    public ParabolaController parabolaController;
    //public bool right = false;
    //public bool left;
    [Range(0, 10)] public float animSpeed;
    public bool isgrounded = true;
    public Transform environment;
    
    public GameObject ground;
    public GameObject spawnPoint;
    public GameObject root;
   

    [Header("SCORE")]
    //public GameObject women;
    public static int level;
    public static int score;
    public int costLevel = 50;  
    public Text scoreText;
    public Animator levelScore;
    public Text levelScoreText;
    
    public GameObject bombParticlePlayer;
    public GameObject coinParticle;
    public Text levelTextCount;
    public Text levelTextCountSlider;
    public Text levelText;
    public static bool counter;

    [Header("COIN MATERIAL")]
    public Material btcMaterial;
    public Material ethMaterial;

    [Header("FINISH")]
    public GameObject mainCamera;
    public Vector3 startCameraPos;
    public Vector3 startCameraRot;

    //[Header("COIN VALUE")]

    ////BTC
    //public Transform btcOk;
    //public int btc;
    //public Text btcValueText;

    ////ETH
    //public Transform ethOk;
    //public int eth;
    //public Text ethValueText;
    int child;
  
    [Header("COIN MATERIAL")]
    public Slider costLevelSlider;
    private void Start()
    {

        //fSpine.SpineTransforms[0].gameObject.SetActive(true);
       


        startCameraPos = mainCamera.transform.position;
        startCameraRot = mainCamera.transform.eulerAngles;
        costLevelSlider.maxValue = costLevel;
        scoreText.text = "$ " + score.ToString();
        transform.position = rightBorder.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        //StartCoroutine(CoinBorsa());

    }
   




   


    private void Update()
    {
        Debug.Log("CostLevel ="+costLevel);
        costLevelSlider.value = score/3;
        Movement();
        Jump();

        if (counter)
        {
           CounterScore();
        }
       
    }
    bool jump;
    int currentScore;


    int value;

    
    int a;




   
    void CounterScore()
    {

        scoreText.text = "$ " + score.ToString();


        //if ((score > 0) && (score < 5)) Upgrade(3);
        //else if ((score > 20) && (score < 100)) Upgrade(1);
        //else if ((score > 300) && (score < 400)) Upgrade(2);

        value = score / 10;

        //for (int div = 10; score != 0; div *= 10)
        //{
        //    int n = score % div;
        //    value = n / 10;
        //    Debug.Log("N =" + n);
        //    score -= n;
        //}


       
        
       
        
      

      

        //if (value > women.transform.childCount)
        //{
        //    value = women.transform.childCount;
        //}
        //Upgrade(value);



       


        //currentScore += 50;

        if (currentScore > score)
        {
            currentScore = score;

            counter = false;
        }
    }
    bool jumpTouch = true;
    private void Jump()
    {
        if ((rb.velocity.y<15)&&jump)
        {
            rb.velocity += Vector3.up * (Physics.gravity.y) * (fallMultilier - 1) * Time.deltaTime;
        }
        if (isgrounded)
        {
            anim.SetBool("Jump", false);
            anim.speed = 1f;
            jumpTouch = true;
        }
        else
        {
            anim.SetBool("Jump", true);
            anim.speed = animSpeed;
            jumpTouch = false;
        }
    }

    private void Movement()
    {
        if (jumpTouch)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                rb.velocity = Vector3.zero;
                rb.velocity = Vector3.up * JumpForce;
                jump = true;


            }
        }
        
        if (isgrounded)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetTrigger("Slide");
                boxCollider.center = new Vector3(boxCollider.center.x, 0.5f, boxCollider.center.z);
                boxCollider.size = new Vector3(boxCollider.size.x, 1f, boxCollider.size.z);
                Invoke("ColliderBack",1.5f);

            }
        }
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    right = true;
        //    left = false;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    right = false;
        //    left = true;
        //}
        //if (right)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(rightBorder.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);
        //}
        //if (left)
        //{
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(leftBorder.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);
        //}








        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (jumpTouch)
            {
                if (touch.deltaPosition.y > 30.0f)
                {
                    rb.velocity = Vector3.zero;
                    rb.velocity = Vector3.up * JumpForce;
                    jump = true;
                    jumpTouch = false;
                }
            }
           
            if (isgrounded)
            {
                if (touch.deltaPosition.y < -30.0f)
                {
                    anim.SetTrigger("Slide");
                    boxCollider.center = new Vector3(boxCollider.center.x, 0.5f, boxCollider.center.z);
                    boxCollider.size = new Vector3(boxCollider.size.x, 1f, boxCollider.size.z);
                    Invoke("ColliderBack", 1.5f);

                }
            }

            //if (touch.deltaPosition.x > 90.0f)
            //{

            //    right = true;
            //    left = false;
            //}
            //if (touch.deltaPosition.x < -30.0f)
            //{
            //    right = false;
            //    left = true;
            //}

            //if (right)
            //{
            //    transform.position = Vector3.Lerp(transform.position, new Vector3(rightBorder.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);
            //}
            //if (left)
            //{
            //    transform.position = Vector3.Lerp(transform.position, new Vector3(leftBorder.position.x, transform.position.y, transform.position.z), Time.deltaTime * speed);

            //}


        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            isgrounded = true;
            cameraController.enabled = false;
            mainCamera.transform.position = ground.transform.position + startCameraPos;
            mainCamera.transform.eulerAngles = startCameraRot;

        }
       

    }

    private void Finish()
    {
        //women.SetActive(false);
        levelText.text = "GAME OVER";
        //Invoke("RestartScene", 8f);
        GetComponent<Player>().enabled = false;
        levelScore.SetTrigger("Finish");
        levelScoreText.text = scoreText.text;
    }

    GameObject otherr;
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            isgrounded = false;
           

        }
        if (nextLevel)
        {
            GameManager.wait = true;
        }
        
    }
    bool nextLevel;
    void ColliderBack()
    {
        boxCollider.center = new Vector3(boxCollider.center.x, 2f, boxCollider.center.z);
        boxCollider.size = new Vector3(boxCollider.size.x, 4f, boxCollider.size.z);
    }

    int add;
    int divition;
    public Transform ThrowParent;
    public GameObject playAgain;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Engel")
        {
            playAgain.SetActive(true);
            parabolaController.Animation = true;
            transform.parent = environment;
            //anim.enabled = false;
            //collision.gameObject.SetActive(false);
            boxCollider.enabled = false;
            rb.velocity = Vector3.up * JumpForce;
            //rb.useGravity = false;
            //rb.mass = 0;
            Finish();

            //StartCoroutine(PlayerYControl());

            Bomb();

        }
        if (other.gameObject.tag == "Throw")
        {
            dolarFlow.SetActive(false);
            anim.SetBool("Skate",false);
            confetti.gameObject.SetActive(true);
            //women.gameObject.SetActive(false);
            int random = UnityEngine.Random.Range(0, 3);
            anim.SetInteger("Dance",random);
            anim.SetTrigger("FinalUp");
            cameraController.enabled = false;
            cameraCircle.enabled = true;
            
           
            //women.GetComponent<WomenParent>().AnimDance(random);
            SoundManagerSfx.PlaySfx("LevelUp");
            add++;
            Invoke("Late", 1f);
            level++;
            levelTextCount.text = level.ToString();
            levelTextCountSlider.text = (level+1).ToString();
            rb.velocity = Vector3.zero;
            gameManager.turnSpeedYedek = gameManager.turnSpeed;
            gameManager.turnSpeed = 0;

            otherr = other.gameObject;



            levelScore.SetTrigger("Start");
            levelScoreText.text = scoreText.text;

            Invoke("Throw", 4.5f);

           


        }
        if (other.gameObject.tag=="Money")
        {
            SoundManagerSfx.PlaySfx("Money");
           
            other.gameObject.transform.parent.gameObject.SetActive(false);
            score += other.GetComponent<Money>().moneyValue;
            scoreText.text = "$ " + score.ToString();
            
            
        }

        if (other.gameObject.tag == "End")
        {
            dolarFlow.SetActive(true);
            anim.SetBool("Skate",true);
            divition = (score / 10);
            Debug.Log("Divition" + divition);
            if (score >= (score - costLevel))
            {

                ThrowParent.GetChild(9).GetChild(2).gameObject.SetActive(true);
                Debug.Log("SCORE =" + score);

            }
            else if (score >= (score - (costLevel - divition))) ThrowParent.GetChild(8).GetChild(2).gameObject.SetActive(true);
            else if (score >= (score - (costLevel - (divition * 2)))) ThrowParent.GetChild(7).GetChild(2).gameObject.SetActive(true);



        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Seviye")
        {


            
            score -= divition;
            scoreText.text = "$ " + score.ToString();
            if (score <= 0)
            {
                playAgain.SetActive(true);
                anim.SetBool("Sad",true);
                gameManager.turnSpeed = 0;
                Finish();
            }
            //else
            //{
            //    Destroy(other.gameObject.transform.parent.gameObject);
            //}
        }
    }
    void Throw()
    {
        cameraCircle.enabled = false;
        cameraCircle.timer = 0;
        cameraController.enabled = true;
        cameraController.DestinationPlayer();
        
        Spawn.finish = false;
        spawn.SpawnEngel();
        costLevel = 250*(level+1);
        costLevelSlider.maxValue = costLevel;
        foreach (Transform item in ThrowParent)
        {
            Destroy(item.gameObject);
        }
        confetti.gameObject.SetActive(false);
        //women.gameObject.SetActive(true);
      
        anim.SetTrigger("LevelUp");
        //women.GetComponent<WomenParent>().AnimRun();
        gameManager.TurnSpeed();
        ground.transform.position = new Vector3(level * 38, ground.transform.position.y, 0);

        spawnPoint.transform.position = new Vector3(-180 - ground.transform.position.x, spawnPoint.transform.position.y, ground.transform.position.z);

        if (add % 2 == 0)
        {
            spawn.toplamEngel += 1;
        }
        root.transform.GetChild(2).transform.position = ground.transform.position + new Vector3(0, 5, 0);
       
        jump = false;
        otherr.transform.parent.GetComponent<Animator>().enabled = true;
       
        parabolaController.touchThrow = true;
        GetComponent<ParabolaController>().FollowParabola();
    }
    private void Late()
    {
        nextLevel = true;
    }
    void Bomb()
    {
        gameObject.SetActive(false);
        Instantiate(bombParticlePlayer, transform.position, Quaternion.identity);
    }
    
   public void RestartScene()
    {
        gameManager.Restart();
    }

    //public FSpineAnimator fSpine;

    //public void Upgrade(int value)
    //{
    //    //cameraController.offset.z = -value;

    //    foreach (Transform item in fSpine.transform)
    //    {
    //        item.gameObject.SetActive(false);
    //    }

    //    for (int i = 1; i < value; i++)
    //    {
    //        fSpine.SpineTransforms[i].gameObject.SetActive(true);
    //    }
    //    //cameraController.offset.z = -value;
    //    counter = false;
    //}




}
