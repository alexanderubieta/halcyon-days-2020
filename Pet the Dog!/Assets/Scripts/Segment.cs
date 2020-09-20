using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int myDirection;
    public Animator segmentANIM;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myDirection = Random.Range(0, 3);
        player = GameObject.Find("Player");
        gameObject.GetComponent<Animator>().runtimeAnimatorController = player.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController;
        segmentANIM.SetInteger("direction", Random.Range(0, 3));
        gameObject.transform.localScale = new Vector3(20f, 20f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
