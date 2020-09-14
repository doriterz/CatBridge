using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctController : MonoBehaviour
{

    public GameObject[] MovementControllers;
    private DestroyObject destroyObject;
    
    void Start()
    {
        destroyObject = FindObjectOfType<DestroyObject>();
    }

    public void DeActivate()
    {
        for (int i = 0; i < MovementControllers.Length; i++)
        {
            if(MovementControllers[i].destroyObject.activated == true)
            {
                MovementControllers[i].SetActive = false;
            }

        }

    }



}
