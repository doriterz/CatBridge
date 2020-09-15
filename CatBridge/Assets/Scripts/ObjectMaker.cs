using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    private PositionController positionController;

    public GameObject[] platformObjects;
    public GameObject[] movementObjects;
    public GameObject platformPositions;
    public GameObject movementObjectsPostitions;    

    public Transform movementHolder;
    public Transform platformHolder;
    

    public int requiredPlatforms;
    public int requiredMovements;
    public int howmanyNeeded;

    // Start is called before the first frame update
    void Start()
    {
        positionController = FindObjectOfType<PositionController>();
        MakeMovements();
        MakePlatforms();
    }


    public void MakeMovements()
    {
        for (int i = 0; i < requiredMovements; i++)
        {
            for (int j = 0; j < howmanyNeeded; j++)
            {
            GameObject movements = Instantiate(movementObjects[i], new Vector3(movementObjectsPostitions.transform.position.x + (i*3), movementObjectsPostitions.transform.position.y, movementObjectsPostitions.transform.position.z), Quaternion.identity);
            movements.transform.SetParent(movementHolder.transform);
            movements.name = "movements" + i + " No." + j;                
            }
        }  
    }

    public void MakePlatforms()
    {
        
        for (int i = 0; i < requiredPlatforms; i++)
        {
            for (int j = 0; j < howmanyNeeded; j++)
            {
            GameObject platform = Instantiate(platformObjects[i], new Vector3(platformPositions.transform.position.x + (i*3), platformPositions.transform.position.y, platformPositions.transform.position.z), Quaternion.identity);
            platform.transform.SetParent(platformHolder.transform);
            platform.name = "platform" + i + " No." + j;                

            }
        } 
    }

    // public void MakeAtkBall()
    // {        
    //     for (int i = 0; i < requiredPlatforms; i++)
    //     {
    //         for (int j = 0; j < howmanyNeeded; j++)
    //         {
    //         GameObject platform = Instantiate(platformObjects[i], new Vector3(platformPositions.transform.position.x + (i*3), platformPositions.transform.position.y, platformPositions.transform.position.z), Quaternion.identity);
    //         platform.transform.SetParent(platformHolder.transform);
    //         platform.name = "platform" + i + " No." + j;                

    //         }
    //     } 
    // }




    public void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
            SetActiveAllChildren(child, value);
        }
    }

    public void DestroyAllChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void moveAllChildren(Transform transform)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.transform.position = new Vector3 (child.gameObject.transform.position.x - 3, child.gameObject.transform.position.y, child.gameObject.transform.position.z);

            if(child.gameObject.transform.position.x < platformPositions.transform.position.x)
            {
                child.gameObject.transform.position = new Vector3 (platformPositions.transform.position.x + (requiredPlatforms*3), child.gameObject.transform.position.y, child.gameObject.transform.position.z);
            }


        }
    }

    public void SetActiveChangeUnusedObjects(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.transform.position.y < -2)
            {
                child.gameObject.SetActive(value);
                SetActiveChangeUnusedObjects(child, value);
            }
        }
    }





}
