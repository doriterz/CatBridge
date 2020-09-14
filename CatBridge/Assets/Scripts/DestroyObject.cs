using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public bool playered;
    public bool activated;
    public LayerMask whatIsPlayer;

    private Collider2D myCollider;


    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    public void Update() {
        playered = Physics2D.IsTouchingLayers(myCollider, whatIsPlayer);
        activatedCheck();
    }


    public void activatedCheck()
    {
        if(playered)
        {
            activated = true;
        }
    }

}
