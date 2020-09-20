using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public AudioSource doggySFX;
    private bool isColliding = false;
    private HazardManager hm;
    private Animator dogANIM;

    void Awake()
    {
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void OnEnable()
    {
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
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
