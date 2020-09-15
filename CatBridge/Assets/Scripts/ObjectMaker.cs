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
    public Transform PrefabHolder;

    public int requiredPlatforms = 7;
    public int requiredMovements = 3;
    public int howmanyNeeded = 8;

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
            movements.transform.SetParent(PrefabHolder.transform);
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
            platform.transform.SetParent(PrefabHolder.transform);
            platform.name = "platform" + i + " No." + j;                

            }
        } 
    }

    public void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
            SetActiveAllChildren(child, value);
        }
    }




}
