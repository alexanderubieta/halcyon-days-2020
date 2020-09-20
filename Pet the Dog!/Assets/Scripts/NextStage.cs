using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public AudioSource doggySFX;
    private bool isColliding = false;
    private HazardManager hm;
    public bool isFirst; // Asks if this is the first stage unlocked
    public float speed = 2.0f; // How fast the dog moves
    private bool movingToBlock = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToBlock)
        {
            if (isFirst) // First dog moves to the left
            {
                transform.position += new Vector3(-(speed * Time.deltaTime), 0, 0);
            }
            else // Second dog moves up
            {
                transform.position += new Vector3(0, (speed * Time.deltaTime), 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doggySFX.Play();
            player.GetComponent<DUMMYmovement>().movementSpeed += 1;
            movingToBlock = true;
        }
    }
}
