using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{

    public float playerSpeed = 0.1f;
    public float jumpHeight = 4.0f;
    
    
    public GameObject startPosition;
    public GameObject player;

    public GameObject finish;    
    public GameObject ground;
    public bool grounded;


    public GameObject jumper;

    private DestroyObject destroyObject;



    // Start is called before the first frame update
    void Start()
    {
        destroyObject = FindObjectOfType<DestroyObject>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

    }


    void OnTriggerEnter2D(Collider2D ground) {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D ground) {
        grounded = false;
    }
    



    public void PlayerMovement()
    {
        if(grounded)
        {
            player.transform.position = new Vector3(player.transform.position.x + playerSpeed, player.transform.position.y, player.transform.position.z);
        }        
    }


    public void ResetButton()
    {
        player.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);

        // destroyObject.DestroyGameObject();
        // player = Instantiate(player, new Vector3(startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z), Quaternion.identity);
    }

    public void PlayerJump()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpHeight;
        Debug.Log("Jump");
    }



}
