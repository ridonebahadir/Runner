using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenParent : MonoBehaviour
{



    int a;
    private void Start()
    {
       
      
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {
           
            gameObject.transform.GetChild(i).GetComponent<Women>().value = (i * 0.09f)+0.10f;
            gameObject.transform.GetChild(i).GetComponent<Women>().child = i;
            

          
        }


       


    }

   public void AnimDance(int a)
    {
        foreach (Transform item in gameObject.transform)
        {
           
            item.GetComponent<Animator>().SetInteger("Dance", a);
            item.GetComponent<Animator>().SetTrigger("FinalUp");
            
        }
    }
    public void AnimRun()
    {
        foreach (Transform item in gameObject.transform)
        {
            item.GetComponent<Animator>().SetTrigger("Jump");
           

        }
    }

    public GameObject A;
    public GameObject B;



    [ContextMenu("PlaceSpheres()")]
    private void DebugPlace()
    {
        PlaceSpheres(A.transform.position, B.transform.position, gameObject.transform.childCount);
    }

    public void PlaceSpheres(Vector3 posA, Vector3 posB, int numberOfObjects)
    {
        // get circle center and radius
        var radius = Vector3.Distance(posA, posB)*1.2f;
        var centerPos = ((posA + posB) / 2f)-new Vector3(70,0,0); //MERKEZ POS
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), centerPos, Quaternion.identity);
        // get a rotation that looks in the direction
        // posA -> posB
        var centerDirection = Quaternion.LookRotation((posA - posB).normalized+new Vector3(6,0,0)); //ROTATÝON

        for (var i = 0; i < numberOfObjects; i++)
        {
                                
            var angle = Mathf.PI * ((i + 1) / (numberOfObjects + 1f))/5; // EÐRÝNÝN DÜZLÜÐÜ
            var x = Mathf.Sin(angle) * radius;
            var z = Mathf.Cos(angle) * radius;
            var pos = new Vector3(x, 0, z);
            // Rotate the pos vector according to the centerDirection
            pos = centerDirection * pos;

            //var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gameObject.transform.GetChild(i).transform.position = centerPos + pos;
            //sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}
