using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{

    public bool Coin20;
    public bool Coin30;
    public bool Coin100;

    public bool playered;
    public bool activated;
    public float damage;
    public LayerMask whatIsPlayer;

    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        damage = 10;
    }

    public void Update() {
        playered = Physics2D.IsTouchingLayers(myCollider, whatIsPlayer);
        if(playered)
        {
            activated = true;
            gameObject.SetActive(false);
            
        }
    }
}
