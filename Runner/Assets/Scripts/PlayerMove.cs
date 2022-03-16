using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
   
    public float speed;
    private float speeed = 15;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Transform rightBorder;
    public Transform leftBorder;
    private Touch touch;
    // Update is called once per frame
    float currLerp = 0;
    
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Camera.main.transform.position.z));
        //    touchStart = true;


        //}
        //if (Input.GetMouseButton(0))
        //{
        //    //touchStart = true;
        //    pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Camera.main.transform.position.z));
        //}
        //else
        //{
        //    touchStart = false;
        //}





        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.DOMoveX(transform.position.x + touch.deltaPosition.x*speed , speed).SetEase(Ease.InOutSine);

                //DOTween.To(DegiskeninDegeriniAl, DegiskeninDegeriniDegistir, speed, speed).SetEase(Ease.InOutQuart);

               

                //transform.position = new Vector3(
                //    transform.position.x + touch.deltaPosition.x * speed,
                //    transform.position.y,
                //    transform.position.z
                //    );
            }
        }






    }
    //public float duration;
   
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);
        }



        if (transform.position.x > rightBorder.position.x)
            transform.position = new Vector3(rightBorder.position.x, transform.position.y, transform.position.z);
        if (transform.position.x < leftBorder.position.x)
            transform.position = new Vector3(leftBorder.position.x, transform.position.y, transform.position.z);


    }
    void moveCharacter(Vector2 direction)
    {
        transform.Translate(direction * speeed * Time.deltaTime);
    }
}