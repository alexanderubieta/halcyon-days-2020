using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject[] stages;
    private int currentArea = 1;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Game starts with area 1, round 1
        stages[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("index"  + index);
    }

    public void NextBatch()
    {
        stages[index].SetActive(false);
        stages[index + 1].SetActive(true);
        index += 1;
    }
}
