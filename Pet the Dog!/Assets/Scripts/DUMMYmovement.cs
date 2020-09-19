using UnityEngine;
using System.Collections;

public class DUMMYmovement : MonoBehaviour
{
    public float movementSpeed = 5f; //movement speed of player
    public Vector2 movement; //movement axis
    public Rigidbody2D rigidbody; // player rigidbody component
    public float runSpeed = 8f;
    //a test
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    bool moveRight = false;
    //bool moveLeft = false;
    bool moveUp = false;
    //bool moveDown = false;
    float storeX = 0;
    float storeY = 0;
    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            //moveLeft = false;
            moveUp = false;
            //oveDown = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            moveRight = true;
            //moveLeft = false;
            moveUp = false;
            //oveDown = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }
        
        if (moveRight)
        {
            movement.x = storeX;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            moveRight = false;
            //moveLeft = false;
            moveUp = true;
            //oveDown = false;
            storeY = Input.GetAxisRaw("Vertical");
            movement.x = 0;
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            moveRight = false;
            //moveLeft = false;
            moveUp = true;
            //oveDown = false;
            storeY = Input.GetAxisRaw("Vertical");
            movement.x = 0;
        }

        if (moveUp)
        {
            movement.y = storeY;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.A)) {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
        
    }
}

    