using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctController : MonoBehaviour
{
   
    private ObjectMaker objectMaker;

    public DestroyObject[] movementObjects;
    public GameObject[] PrefabObjects;
    void Start()
    {
        //destroyObject = FindObjectOfType<DestroyObject>();
        objectMaker = FindObjectOfType<ObjectMaker>();

    }



    public void DeActivate()
    {

    //     for (int i = 0; i < movementObjects.Length; i++)
    //     {
    //         if(movementObjects[i].activated)
    //         {
    //             //movementObjects[i].DeActivatedCheck();
    //             PrefabObjects[i].SetActive(false);
    //         }
    //     }
    }

    public void ReActivate()
    {
        // for (int i = 0; i < length; i++)
        // {
            
        // }
    }


}
