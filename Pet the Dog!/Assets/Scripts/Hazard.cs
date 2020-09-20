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
    private Sprite mySprite;
    private TextMaker tm;
    public string truth;


    void Awake()
    {
        myCamera = GameObject.Find("Main Camera");
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
        trueForm = gameObject.transform.GetChild(1).gameObject;
        trueForm.SetActive(false);
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
        mySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        tm = GameObject.Find("TextMaker").GetComponent<TextMaker>();
        
    }

    void OnEnable()
    {
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mySprite;
        gameObject.GetComponent<Transform>().localScale = new Vector3(13, 13, 13);
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
            trueForm.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            tm.phrase = truth;
            tm.Exclaim();

            // The following code ensures that BackBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.BackBatch();
        }
    }
}
