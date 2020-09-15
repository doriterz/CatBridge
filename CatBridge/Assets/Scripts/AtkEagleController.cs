using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkEagleController : MonoBehaviour
{

    public GameObject eagle;
    public bool eagleActivator;
    public bool eagleLanded;
    public float eagleDropSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(eagleActivator)
        {
            eagle.transform.position = new Vector3 (eagle.transform.position.x, eagle.transform.position.y - eagleDropSpeed, eagle.transform.position.z);
        }
        if (eagleLanded)
        {
            gameObject.SetActive(false);
        }
        if (eagle.transform.position.y <= -20)
        {
            gameObject.SetActive(false);
        }



    }
}
