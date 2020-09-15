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

    public int requiredPlatforms = 5;
    public int requiredMovements = 3;
    public int howmanyNeeded = 3;

    // Start is called before the first frame update
    void Start()
    {
        positionController = FindObjectOfType<PositionController>();


        for (int i = 0; i < requiredPlatforms; i++)
        {
            for (int j = 0; j < howmanyNeeded; j++)
            {
            GameObject platform = Instantiate(platformObjects[i], new Vector3(platformPositions.transform.position.x + (i*5) + j, platformPositions.transform.position.y, platformPositions.transform.position.z), Quaternion.identity);

            platform.name = "platform" + i + " No." + j;                
            }
        }  

        for (int i = 0; i < requiredMovements; i++)
        {
            for (int j = 0; j < howmanyNeeded; j++)
            {
            GameObject movements = Instantiate(movementObjects[i], new Vector3(movementObjectsPostitions.transform.position.x + (i*5) + j, movementObjectsPostitions.transform.position.y, movementObjectsPostitions.transform.position.z), Quaternion.identity);

            movements.name = "movements" + i + " No." + j;                
            }
        }  




    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
