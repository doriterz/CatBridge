using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    private ObjectMaker objectMaker;
    public Text objectSwitcherText;
    public bool objectSwitch;


    // Start is called before the first frame update
    void Start()
    {
        objectMaker = FindObjectOfType<ObjectMaker>();
        objectSwitcherText.text = "Platforms";
        objectSwitch = false;
        ObjectSwitcher();

    }

    public void ObjectMover() // switch between platforms and movements
    {
        if(objectSwitch)
        {
            objectMaker.moveAllChildren(objectMaker.platformHolder);
        } else
        {
            objectMaker.moveAllChildren(objectMaker.movementHolder);
        }
    }

    public void ObjectSwitcher()
    {
        if(objectSwitch)
        {
            objectMaker.SetActiveChangeUnusedObjects(objectMaker.platformHolder, false);
            objectMaker.SetActiveChangeUnusedObjects(objectMaker.movementHolder, true);
            objectSwitch = false;
            objectSwitcherText.text = "To\n Platforms";
        } else
        {
            objectMaker.SetActiveChangeUnusedObjects(objectMaker.movementHolder, false);
            objectMaker.SetActiveChangeUnusedObjects(objectMaker.platformHolder, true);
            objectSwitch = true;
            objectSwitcherText.text = "To\n Movements";           
        }

    }

}
