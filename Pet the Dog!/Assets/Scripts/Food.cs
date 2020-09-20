using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public AudioSource gotFoodSFX;
    public AudioSource healSFX;
    private bool isColliding = false;
    private Animator dogANIM;
    public Sprite trueForm;
    public GameObject trueFormObject;
    private TextMaker tm;
    public string truth;

    void Awake()
    {
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
        tm = GameObject.Find("TextMaker").GetComponent<TextMaker>();
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

            tm.phrase = truth;
            tm.Exclaim();


            GameObject temp = Instantiate(trueFormObject, gameObject.GetComponent<Transform>());
            temp.GetComponent<SpriteRenderer>().sprite = trueForm;
            temp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            temp.transform.parent = null;

            other.GetComponent<PlayerHealth>().arms += 1; // Add an arm from the Player
            Destroy(gameObject);

        }
    }
}
