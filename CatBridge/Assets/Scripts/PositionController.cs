using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

    public Transform startPosition;
    public Transform finishPosition;
    
    [SerializeField]
    public int horizontalDistance;

    [SerializeField]
    public int verticalDistance;

    void start()
    {
        startSetting();
    }

    void startSetting()
    {
        //vertical Max must be less than 128 * 6, and horizontal Max must be less than 128 * 11
        startPosition.transform.position = new Vector3 (startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);
        finishPosition.transform.position = new Vector3 (startPosition.transform.position.x + horizontalDistance, startPosition.transform.position.y - verticalDistance, startPosition.transform.position.z);

    }

    // void RandomDistance()
    // {
    //     horizontalDistance = (int)Random.Range(15f, 20f);
    //     verticalDistance = (int)Random.Range(-5f, 5f);
    // }

    

}
