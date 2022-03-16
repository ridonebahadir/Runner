using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Women : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    public float value;
    private Vector3 velocity = Vector3.zero;
    Vector3 startpos;
    public GameObject particle;
    public Vector3 target;
    public int child;
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Human");
        //random = Random.Range(0.0f, 1.0f);
        startpos = transform.position /*- player.transform.position*/;
       
        StartCoroutine(Late());
        
        //Instantiate(particle,transform.position,Quaternion.identity);
    }

    void Update()
    {

        StartCoroutine(Late());
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), ref velocity, 0.1f);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 0.3f);

        //if (playerScript.right)
        //{
        //    //StartCoroutine(Late(new Vector3(startpos.x + 6, transform.position.y, transform.position.z)));
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + startpos.x, transform.position.y, transform.position.z), Time.deltaTime * playerScript.speed*value);

        //}
        //if (playerScript.left)
        //{
        //    //StartCoroutine(Late(new Vector3(startpos.x - 6, transform.position.y, transform.position.z)));
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x - startpos.x, transform.position.y, transform.position.z), Time.deltaTime * playerScript.speed*value);
        //}


    }
   IEnumerator Late()
    {
        float time = value; 
        float gecenSure = 0f;

        Vector3 mevcutKonum = transform.position;
        Vector3 hedefKonum = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);

        while (gecenSure < time) 
        {
            gecenSure += Time.deltaTime;
            transform.position = Vector3.Lerp(mevcutKonum, hedefKonum, gecenSure / time);
            //transform.rotation = Quaternion.LookRotation(transform.position - target);
            yield return null;
        }

       
        transform.position = hedefKonum;
    }

    //IEnumerator Late()
    //{
    //    float time = value;
    //    float gecenSure = 0f;

    //    Vector3 mevcutKonum = transform.position;
    //    Vector3 hedefKonum = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    //    while (gecenSure < time)
    //    {
    //        gecenSure += Time.deltaTime;
    //        transform.position = Vector3.Lerp(mevcutKonum, hedefKonum, gecenSure / time);

    //        yield return null;
    //    }


    //    transform.position = hedefKonum;
    //}
}
