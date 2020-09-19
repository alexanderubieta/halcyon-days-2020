using UnityEngine;
using System.Collections;

public class DUMMYmovement : MonoBehaviour
{

    public float movementSpeed = 5f; //movement speed of player
    public Vector2 movement; //movement axis
    public Rigidbody2D rigidbody; // player rigidbody component
    public float runSpeed = 10f;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    bool moveVert = false;
    bool moveHori = false;
    float storeX = 0;
    float storeY = 0;
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            moveVert = true;
            moveHori = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVert = true;
            moveHori = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
        }

        if (moveVert)
        {
            movement.x = storeX;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveVert = false;
            moveHori = true;
            storeY = Input.GetAxisRaw("Vertical");
            movement.x = 0;

        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVert = false;
            moveHori = true;
            storeY = Input.GetAxisRaw("Vertical");
            movement.x = 0;
        }

        if (moveHori)
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

        if (Input.GetKey(KeyCode.A))
        {
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

