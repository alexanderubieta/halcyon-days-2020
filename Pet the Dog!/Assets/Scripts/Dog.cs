using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public AudioSource doggySFX;
    private bool isColliding = false;
    private HazardManager hm;

    void Awake()
    {
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
    }

    void Update()
    {
        isColliding = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doggySFX.Play();

            // The following code ensures that NextBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.NextBatch();
        }
    }
}
