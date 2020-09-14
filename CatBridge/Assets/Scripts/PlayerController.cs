using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject startPosition;

    public float moveSpeed;
    public float jumpForce;
    public float RighterMoveSpeed;
    public float LefterMoveSpeed;
    public float downerMoveSpeed;
    


    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private DestroyObject destroyObject;

    public bool grounded;
    public LayerMask whatIsGround;

    public bool jumpered;
    public LayerMask whatisJumper;

    public bool downered;
    public LayerMask whatisDowner;

    public bool leftered;
    public LayerMask whatisLefter;

    public bool rightered;
    public LayerMask whatisRighter;
    public float righteredTimer = 1f;
    public float rightTimer;
    


    

    // Start is called before the first frame update
    void Start()
    {
        RighterMoveSpeed = moveSpeed * 2;
        LefterMoveSpeed = moveSpeed * -2;
        downerMoveSpeed = jumpForce * -1;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        destroyObject = FindObjectOfType<DestroyObject>();
        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        rightTimer += Time.deltaTime;
        if(rightTimer > righteredTimer) //activated가 되면
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        }

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        jumpered = Physics2D.IsTouchingLayers(myCollider, whatisJumper);
        downered = Physics2D.IsTouchingLayers(myCollider, whatisDowner);
        leftered = Physics2D.IsTouchingLayers(myCollider, whatisLefter);
        rightered = Physics2D.IsTouchingLayers(myCollider, whatisRighter);

        //myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);

        // if(Input.GetKeyDown(KeyCode.Space)) //|| Input.GetMouseButtonDown(0))
        // {
        //     if(grounded)
        //     {
        //         myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //     }
        // }

        if(jumpered)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            Debug.Log("Jumping");
        }
        
        if(downered)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, downerMoveSpeed);
            Debug.Log("Downing");

        }   

        if(leftered)
        {
            if (destroyObject.activated == false)
            {
                myRigidbody.velocity = new Vector2(LefterMoveSpeed, myRigidbody.velocity.y);
                Debug.Log("Lefting");
            }                 
        }        
        
        if(rightered)
        {
            if (destroyObject.activated == false)
            {
                myRigidbody.velocity = new Vector2(RighterMoveSpeed, myRigidbody.velocity.y);
                Debug.Log("Righting");
                rightTimer = 0;
            }

             

        }

    }

    public void ResetPlayer() 
    {
        this.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }


    public void ResetButton()
    {
        ResetPlayer();      
    }
}
