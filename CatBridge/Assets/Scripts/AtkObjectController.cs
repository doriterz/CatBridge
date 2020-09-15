using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkObjectController : MonoBehaviour
{

    private HealthBar healthBar;

    public bool AtkBall;
    public bool AtkEagle;

    public bool playered;
    public bool activated;
    public float damage;
    public LayerMask whatIsPlayer;

    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        healthBar = FindObjectOfType<HealthBar>();

        damage = 10;
    }

    public void Update() {
        playered = Physics2D.IsTouchingLayers(myCollider, whatIsPlayer);
        if(playered)
        {
            activated = true;
            healthBar.damage = damage;
            healthBar.Health();
            gameObject.SetActive(false);
            
        }
    }
}
