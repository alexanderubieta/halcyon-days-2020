using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource damagedSFX;
    private HazardManager hm;
    private bool isColliding = false;

    void Awake()
    {
        myCamera = GameObject.Find("Main Camera");
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
            damagedSFX.Play();
            other.GetComponent<PlayerHealth>().arms -= 1; // Remove an arm from the Player
            myCamera.GetComponent<CameraShake>().TriggerShake();

            // The following code ensures that BackBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.BackBatch();

            
        }
    }
}
