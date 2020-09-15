using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject startPosition;

    public float movementKind;
    public float moveSpeed;

    public float jumpForce;
    public float RighterMoveSpeed;
    public float LefterMoveSpeed;
    public float downerMoveSpeed;
    


    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private DestroyObject destroyObject;
    private ObejctController obejctController;

    public bool grounded;
    public LayerMask whatIsGround;

    public bool jumpered;
    public LayerMask whatisJumper;

    public bool downered;
    public LayerMask whatisDowner;

    public bool leftered;
    public LayerMask whatisLefter;
    public float lefteredTimer = 1f;
    public float leftTimer;

    public bool rightered;
    public LayerMask whatisRighter;
    public float righteredTimer = 1f;
    public float rightTimer;
    
    public bool killLine;
    public LayerMask whatIsKillLine;

    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        destroyObject = FindObjectOfType<DestroyObject>();
        obejctController = FindObjectOfType<ObejctController>();
        
        this.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y + 1, startPosition.transform.position.z);

        RighterMoveSpeed = moveSpeed * 3;
        LefterMoveSpeed = moveSpeed * -2;
        downerMoveSpeed = jumpForce * -1;
        movementKind = 0;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        jumpered = Physics2D.IsTouchingLayers(myCollider, whatisJumper);
        downered = Physics2D.IsTouchingLayers(myCollider, whatisDowner);
        leftered = Physics2D.IsTouchingLayers(myCollider, whatisLefter);
        rightered = Physics2D.IsTouchingLayers(myCollider, whatisRighter);
        killLine = Physics2D.IsTouchingLayers(myCollider, whatIsKillLine);

        // if(grounded && movementKind == 0)
        // {
        //     myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        // }


        movementControl();


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
            obejctController.DeActivate();
        }
        
        if(downered)
        {
            // myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, downerMoveSpeed);
            // Debug.Log("Downing");
            // obejctController.DeActivate();
        }   

        if(leftered)
        {
            movementKind = 1;
            //movementControl();
            Debug.Log("Lefting");
            leftTimer = 0;
            obejctController.DeActivate();   
        }        
        leftTimer += Time.deltaTime;
        if(leftTimer > lefteredTimer && movementKind != 2) //activated가 되면 1초뒤 원래로
        {
            movementKind = 0;
        }
        
        if(rightered)
        {
            movementKind = 2;
            //movementControl();            
            Debug.Log("Righting");
            rightTimer = 0;
            obejctController.DeActivate();         
        }
        rightTimer += Time.deltaTime;
        if(rightTimer > righteredTimer && movementKind != 1) //activated가 되면 1초뒤 원래로
        {
            movementKind = 0;
        }

        

        if(killLine)
        {
            ResetPlayer();
        }




    }



    void movementControl()
    {
        if(movementKind == 1) //left
        {
            myRigidbody.velocity = new Vector2(LefterMoveSpeed, myRigidbody.velocity.y);
        } else if (movementKind == 2) //right
        {
            myRigidbody.velocity = new Vector2(RighterMoveSpeed, myRigidbody.velocity.y);
        } else if (movementKind == 0) //grounded
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        } 

    }




    public void ResetPlayer() 
    {
        this.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y + 1, startPosition.transform.position.z);
        movementKind = 0;
        obejctController.ReActivate();
    }


    public void ResetButton()
    {
        ResetPlayer();      
    }
}
