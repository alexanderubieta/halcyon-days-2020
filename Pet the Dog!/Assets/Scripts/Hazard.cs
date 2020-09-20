using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource damagedSFX;
    private HazardManager hm;
    private bool isColliding = false;
    public GameObject trueForm;
    private Animator dogANIM;

    void Awake()
    {
        myCamera = GameObject.Find("Main Camera");
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
        trueForm = gameObject.transform.GetChild(1).gameObject;
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
            damagedSFX.Play();
            other.GetComponent<PlayerHealth>().arms -= 1; // Remove an arm from the Player
            myCamera.GetComponent<CameraShake>().TriggerShake();
            trueForm.SetActive(true);
            trueForm.GetComponent<Transform>().parent = null;

            // The following code ensures that BackBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.BackBatch();

            
        }
    }
}
