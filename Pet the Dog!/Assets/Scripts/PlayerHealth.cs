using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int arms = 1; // This acts as the player's health bar.

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("wa");

        if (arms < 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
