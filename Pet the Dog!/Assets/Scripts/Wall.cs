using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource damagedSFX;

    void Awake()
    {
        myCamera = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            damagedSFX.Play();
            other.GetComponent<PlayerHealth>().arms -= 1; // Remove an arm from the Player
            myCamera.GetComponent<CameraShake>().TriggerShake();
        }
    }
}
