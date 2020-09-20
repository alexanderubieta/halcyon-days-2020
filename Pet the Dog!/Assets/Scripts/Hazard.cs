using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject myCamera;
    public AudioSource damagedSFX;
    private HazardManager hm;
    private bool isColliding = false;
    public Sprite trueForm;
    private Animator dogANIM;
    private TextMaker tm;
    public string truth;
    public GameObject trueFormObject;


    void Awake()
    {
        myCamera = GameObject.Find("Main Camera");
        hm = GameObject.Find("HazardMGR").GetComponent<HazardManager>();
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
        tm = GameObject.Find("TextMaker").GetComponent<TextMaker>();
        
    }

    void OnEnable()
    {
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void OnDisable()
    {
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

            
            tm.phrase = truth;
            tm.Exclaim();


            GameObject temp = Instantiate(trueFormObject, gameObject.GetComponent<Transform>());
            temp.GetComponent<SpriteRenderer>().sprite = trueForm;
            temp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            temp.transform.parent = null;

            // The following code ensures that BackBatch only runs once.
            if (isColliding) return;
            isColliding = true;
            hm.BackBatch();
        }
    }
}
