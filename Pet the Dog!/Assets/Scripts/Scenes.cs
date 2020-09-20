using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject instructionsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaveTitleScreen()
    {
        titleScreen.SetActive(false);
        instructionsScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
