using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEditor;

public class DUMMYmovement : MonoBehaviour
{

    public float movementSpeed = 6f; //movement speed of player
    public Vector2 movement; //movement axis
    public new Rigidbody2D rigidbody; // player rigidbody component
    public float runSpeed = 10f;
    public List<Transform> tail;
    public int arms;
    public GameObject armPrefab;
    public Animator petterANIM;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        arms = GetComponent<PlayerHealth>().arms;
        tail = new List<Transform>(arms);
        for (int i = 0; i < arms; i++)
        {
            GameObject arm = (GameObject)Instantiate(armPrefab, rigidbody.position, Quaternion.identity);
            tail.Insert(0,arm.transform);
            //links.Insert(0,rigidbody.position-movement);
        }
    }

    bool moveVert = false;
    bool moveHori = false;
    float storeX = 0;
    float storeY = 0;
    void Update()
    {
        if (GetComponent<PlayerHealth>().arms != arms)
        {
            if (GetComponent<PlayerHealth>().arms > arms)
            {
                GameObject arm = (GameObject)Instantiate(armPrefab, rigidbody.position, Quaternion.identity);
                tail.Insert(0,arm.transform);
                arms=GetComponent<PlayerHealth>().arms;
            }
            else if (GetComponent<PlayerHealth>().arms<arms)
            {
                tail.RemoveAt(tail.Count-1);
                arms=GetComponent<PlayerHealth>().arms;
            }
        }
        
        if (arms > 0)
        {
            var store = tail[0].position;
            tail[0].position = rigidbody.position - movement;
            for (var i = 1; i < tail.Count; i++)
            {
                var store2 = tail[i].position;
                tail[i].position = store-(Vector3)movement;
                store = store2;
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveVert = true;
            moveHori = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
            petterANIM.SetBool("right", true);
            petterANIM.SetBool("left", false);
            petterANIM.SetBool("up", false);
            petterANIM.SetBool("down", false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            moveVert = true;
            moveHori = false;
            storeX = Input.GetAxisRaw("Horizontal");
            movement.y = 0;
            petterANIM.SetBool("right", false);
            petterANIM.SetBool("left", true);
            petterANIM.SetBool("up", false);
            petterANIM.SetBool("down", false);
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
            petterANIM.SetBool("right", false);
            petterANIM.SetBool("left", false);
            petterANIM.SetBool("up", true);
            petterANIM.SetBool("down", false);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            moveVert = false;
            moveHori = true;
            storeY = Input.GetAxisRaw("Vertical");
            movement.x = 0;
            petterANIM.SetBool("right", false);
            petterANIM.SetBool("left", false);
            petterANIM.SetBool("up", false);
            petterANIM.SetBool("down", true);
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
            //this.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            //this.GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);

    }
}

