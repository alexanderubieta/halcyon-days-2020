using UnityEngine;
using System.Collections;

public class DUMMYMovement : MonoBehaviour
{

    public float movementSpeed = 5f; //movement speed of player
    public Vector2 movement; //movement axis
    public Rigidbody2D rigidbody; // player rigidbody component
    public float runSpeed = 10f;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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

    