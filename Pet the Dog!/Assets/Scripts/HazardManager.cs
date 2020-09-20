using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject[] stages;
    public int index = 0;
    public int area1Threshold = 8; // What round the player should be on before unlocking area 2
    public int area2Threshold = 15; // What round the player should be on before unlocking the entire house
    public int winThreshold = 20; // What round the play should pass to win the game
    public GameObject area2; // Stores the block that covers area 2
    public GameObject area3; // Store the block that covers the rest of the house

    // The house is split into 3 stages: Area 1 (kitchen), Area 2 (kitchen & living room), and Area 3 (entire house)

    void Start()
    {
        // Game starts with area 1, round 1
        stages[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // The current stage/round should be the only one active. All others are set inactive.
        stages[index].SetActive(true);
        for (int i = 0; i < stages.Length; i++) 
        {
            if (i != index)
            {
                stages[i].SetActive(false);
            }
        }

        // Remove area 2's barrier if the player has passed its threshold
        if (index >= area1Threshold)
        {
            area2.SetActive(false);
        }

        // Remove area 3's barrier if the player has passed its threshold (entire house is unlocked now)
        if (index >= area2Threshold)
        {
            area3.SetActive(false);
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
