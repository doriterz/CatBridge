using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject startPosition;

    public float movementKind;

    public float moveSpeed;
    public float jumpForce;
    public float RighterMoveSpeed;
    public float LefterMoveSpeed;
    public float downerMoveSpeed;
    
    public Text playerSpeedText;
    public Text leftSpeedText;
    public Text rightSpeedText;
    public Text jumpForceText;
    public Text lefttimeText;
    public Text righttimeText;


    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    private AtkEagleController atkEagleController;
    private AtkObjectController atkObjectController;
    private DestroyObject destroyObject;
    private ObejctController obejctController;
    private ObjectMaker objectMaker;
    private HealthBar healthBar;

    public bool grounded;
    public LayerMask whatIsGround;

    public bool jumpered;
    public LayerMask whatisJumper;

    public bool downered;
    public LayerMask whatisDowner;

    public bool leftered;
    public LayerMask whatisLefter;
    public float lefteredTimer = 3f;
    public float leftTimer;

    public bool rightered;
    public LayerMask whatisRighter;
    public float righteredTimer = 3f;
    public float rightTimer;
    
    public bool killLine;
    public LayerMask whatIsKillLine;

    public bool AtkBall;
    public LayerMask whatIsAtkBall;

    public bool EagleTrigger;
    public LayerMask whatIsEagleTrigger;
    public bool Eagle;
    public LayerMask whatIsEagle;    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        destroyObject = FindObjectOfType<DestroyObject>();
        obejctController = FindObjectOfType<ObejctController>();
        objectMaker = FindObjectOfType<ObjectMaker>();
        atkObjectController = FindObjectOfType<AtkObjectController>();
        atkEagleController = FindObjectOfType<AtkEagleController>();
        healthBar = FindObjectOfType<HealthBar>();
        
        this.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y + 1, startPosition.transform.position.z);

        moveSpeed = 2.9f;
        player();
        LefterMoveSpeed = -14.9f;
        left();
        RighterMoveSpeed = 14.9f;
        right();
        jumpForce = 9.9f;
        jump();
        lefteredTimer = 0.3f;
        lefttimeup();
        righteredTimer = 0.3f;
        righttimeup();

        // RighterMoveSpeed = moveSpeed * 3;
        // LefterMoveSpeed = moveSpeed * -2;
        // downerMoveSpeed = jumpForce * -1;
        // movementKind = 0;
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
        AtkBall = Physics2D.IsTouchingLayers(myCollider, whatIsAtkBall);
        EagleTrigger = Physics2D.IsTouchingLayers(myCollider, whatIsEagleTrigger);
        Eagle = Physics2D.IsTouchingLayers(myCollider, whatIsEagle);

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
            //destroyObject.DeActivatedCheck();
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
            //destroyObject.DeActivatedCheck();
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
            //destroyObject.DeActivatedCheck();
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


        if(AtkBall)
        {
            if(healthBar.current <= 0)
            {
                Debug.Log("player Dead");
                ResetPlayer();
                healthBar.current = 100;
            }
        }


        if(EagleTrigger)
        {
            atkEagleController.eagleActivator = true;
        }    

        if(Eagle)
        {
            atkEagleController.eagleLanded = false;
            if(!atkEagleController.eagleLanded)
            {
                healthBar.damage = 50;
                healthBar.Health();
            }
            atkEagleController.eagleLanded = true;
            if(healthBar.current <= 0)
            {
                Debug.Log("player Dead");
                ResetPlayer();
                healthBar.current = 100;
            }
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
        Time.timeScale = 1;
        objectMaker.SetActiveAllChildren(objectMaker.movementHolder, true);
     
    }

    public void HardResetPlayer() 
    {
        this.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y + 1, startPosition.transform.position.z);
        movementKind = 0;
        Time.timeScale = 1;
        moveSpeed = 2.9f;
        player();
        LefterMoveSpeed = -14.9f;
        left();
        RighterMoveSpeed = 14.9f;
        right();
        jumpForce = 9.9f;
        jump();
        lefteredTimer = 0.3f;
        lefttimeup();
        righteredTimer = 0.3f;
        righttimeup();
        objectMaker.SetActiveAllChildren(objectMaker.movementHolder, true);
    }

    public void ResetMap()
    {
        objectMaker.DestroyAllChildren(objectMaker.movementHolder);
        objectMaker.DestroyAllChildren(objectMaker.platformHolder);
        objectMaker.MakeMovements();
        objectMaker.MakePlatforms();
    }



    public void player()
    {
        moveSpeed += 0.1f;
        playerSpeedText.text = "PlayerSpeed" + moveSpeed.ToString("F1");
    }
    public void playerminus()
    {
        moveSpeed -= 0.1f;
        playerSpeedText.text = "PlayerSpeed" + moveSpeed.ToString("F1");
    }
    public void left()
    {
        LefterMoveSpeed -= 0.1f;
        leftSpeedText.text = "LSpeed" + LefterMoveSpeed.ToString("F1");
    }    
    public void leftminus()
    {
        LefterMoveSpeed += 0.1f;
        leftSpeedText.text = "LSpeed" + LefterMoveSpeed.ToString("F1");
    }  
    public void right()
    {
        RighterMoveSpeed += 0.1f;
        rightSpeedText.text = "RSpeed" + RighterMoveSpeed.ToString("F1");
    }    
    public void rightminus()
    {
        RighterMoveSpeed -= 0.1f;
        rightSpeedText.text = "RSpeed" + RighterMoveSpeed.ToString("F1");
    } 
    public void jump()
    {
        jumpForce += 0.1f;
        jumpForceText.text = "JForce" + jumpForce.ToString("F1");
    }
    public void jumpminus()
    {
        jumpForce -= 0.1f;
        jumpForceText.text = "JForce" + jumpForce.ToString("F1");
    }
    public void lefttimeup()
    {
        lefteredTimer += 0.1f;
        lefttimeText.text = "LTime" + lefteredTimer.ToString("F1");
    }
    public void lefttimeminus()
    {
        lefteredTimer -= 0.1f;
        lefttimeText.text = "LTime" + lefteredTimer.ToString("F1");
    }
        public void righttimeup()
    {
        righteredTimer += 0.1f;
        righttimeText.text = "RTime" + righteredTimer.ToString("F1");
    }
    public void righttimeminus()
    {
        righteredTimer -= 0.1f;
        righttimeText.text = "RTime" + righteredTimer.ToString("F1");
    }
    public void ResetButton()
    {
        ResetPlayer();      
    }

    public void pause()
    {
        Time.timeScale = 0;
    }



}
