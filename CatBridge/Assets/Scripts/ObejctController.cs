using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctController : MonoBehaviour
{
   
    public DestroyObject[] movementObjects;

    void Start()
    {
        //destroyObject = FindObjectOfType<DestroyObject>();
    }



    public void DeActivate()
    {

        for (int i = 0; i < movementObjects.Length; i++)
        {
            if(movementObjects[i].activated)
            {
                movementObjects[i].DeActivatedCheck();
            }
        }
    }

    public void ReActivate()
    {
        for (int i = 0; i < movementObjects.Length; i++)
        {
            if(movementObjects[i].activated)
            {
                movementObjects[i].ReActivatedCheck();
                movementObjects[i].activated = false;
            }
        }
    }


}
