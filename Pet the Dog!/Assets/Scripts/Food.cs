using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public AudioSource gotFoodSFX;
    public AudioSource healSFX;
    private bool isColliding = false;
    private Animator dogANIM;

    void Awake()
    {
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void Update()
    {
        isColliding = false;
    }

    void OnEnable()
    {
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gotFoodSFX.Play();
            healSFX.Play();
            other.GetComponent<PlayerHealth>().arms += 1; // Add an arm from the Player
            Destroy(gameObject);

        }
    }
}
