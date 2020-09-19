using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColliding = false;
    private HazardManager hm;

    void Start()
    {
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dog")
        {
            Debug.Log("Thats the block!");
            // The following code ensures that NextBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.NextBatch();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
