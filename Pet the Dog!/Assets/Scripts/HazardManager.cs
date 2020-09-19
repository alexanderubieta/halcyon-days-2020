using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject[] stages;
    private int currentArea = 1;
    public int index = 0;
    public int area1Threshold = 5; // How many times the player should've pet the dog before unlocking Area 2
    public int area2Threshold = 15; // How many times the player should've pet the dog before unlocking the entire house
    public int pets = 0; // How many times the player has pet the dog


    // Start is called before the first frame update
    void Start()
    {
        // Game starts with area 1, round 1
        stages[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        stages[index].SetActive(true);

        for (int i = 0; i < stages.Length; i++)
        {
            if (i != index)
            {
                stages[i].SetActive(false);
            }
        }
    }

    public void NextBatch() //Move onto the next round of objects
    {
        index += 1;
    }

    public void BackBatch() //Revert to a prior round
    {
        stages[index].SetActive(false); //Turn off the current set

        if (index - 2 >= 0) // If the scene is able to go back 2 rounds, do so
        {
            index -= 2;
        }

        else if (index - 1 >= 0)
        {
            index -= 1;
        }

        else
        {
            index += 1;
        }
        
    }
}
