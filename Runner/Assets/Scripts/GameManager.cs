using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public GameObject cube;
    //public List<GameObject> cubes;

    public GameObject environment;
    public Transform environmentRing;
    public GameObject ring;
   
    public List<GameObject> rings;
    public int unit;
    [Range(0, 100)]
    public float turnSpeed;
    public float turnSpeedYedek;
    public Color[] color;

    [Header("COINS")]
    public static int sira = 0;
    public Transform Coins;
    public Text firstCoinText;
    public Text secondCoinText;
    public Image firstCoinImage;
    public Image secondCoinImage;
    public static bool wait;
    int colorCount = 0;
    private void Awake()
    {
       
        for (int i = 0; i < unit; i++)
        {
            //spawnPoint.transform.position = new Vector3(-180 - ground.transform.position.x, ground.transform.position.y, ground.transform.position.z);

            //GameObject cubeClone = Instantiate(cube, environmentRing);
            //cubes.Add(cubeClone);
            //cubeClone.transform.localPosition = new Vector3(0, (i * 5f), 0);
            //cubeClone.SetActive(false);



            GameObject obj= Instantiate(ring, environmentRing);
            rings.Add(obj);
            obj.transform.localPosition=new Vector3(0,0,0);
            obj.transform.Rotate(obj.transform.rotation.x,transform.rotation.y+(i*10),transform.rotation.z);
            if (colorCount >= color.Length)
            {
                colorCount = 0;
            }
            obj.transform.GetChild(0).GetComponent<Renderer>().material.color = color[colorCount];
            colorCount++;
            obj.SetActive(false);
        }
        Invoke("Spawnn", 0.2f);
        Invoke("Wait", 5f);

    }
   
    // Update is called once per frame
    void Update()
    {
        environment.transform.Rotate(new Vector3(0, 1 * turnSpeed * Time.deltaTime, 0));

    }
    void Wait()
    {
        wait = true;
    }
    public void Restart()
    {
        
        Player.level = 0;
        Player.score = 0;
        Spawn.finish = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void Spawnn()
    {
        for (int i = 0; i < unit; i++)
        {
            rings[i].GetComponent<PlanetRing>().innerRadius = i * 0.48f + 1f;
            rings[i].name = i.ToString()+" Ring";
            rings[i].gameObject.SetActive(true);
        }

        //for (int i = 0; i < unit; i++)
        //{
        //    cubes[i].transform.localPosition = rings[i].transform.localPosition;
        //    cubes[i].name = i.ToString() + " Cubes"; ;
        //    cubes[i].gameObject.SetActive(true);
        //}
    }
    public void TurnSpeed()
    {
        turnSpeed = turnSpeedYedek;
        if (Player.level%2==0)
        {
          
            turnSpeed -= 2;
        }
       
    }
   
}
