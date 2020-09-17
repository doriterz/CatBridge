using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public bool playered;
    public bool activated;
    public LayerMask whatIsPlayer;

    private Collider2D myCollider;
    public float destroytimer;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();

    }

    public void Update() {
        playered = Physics2D.IsTouchingLayers(myCollider, whatIsPlayer);
        if(playered)
        {
            destroytimer = 0;
            activated = true;            
        }
        if(activated)
        {
            destroytimer += Time.deltaTime;
            if(destroytimer > 1)
            {
                gameObject.SetActive(false);
                
            }
        }
    }
}
