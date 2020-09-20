using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColliding = false;
    private HazardManager hm;
    public GameObject otherDogForm;

    void Start()
    {
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dog")
        {
            // The following code ensures that NextBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.NextBatch();

            Destroy(other.gameObject);
            gameObject.SetActive(false);
            otherDogForm.SetActive(true); // Activates a new normal dog where the other one was destroyed
        }
    }
}
