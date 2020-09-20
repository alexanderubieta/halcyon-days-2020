using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMaker : MonoBehaviour
{
    public float timer = 1;
    public float textCooldown = 1;
    public Text textObject;
    private bool rightOrLeft; // Will the text appear on the right or left? Right = true, Left = false.
    string[] dialogue = { "doggy?", "c'mere puppy", "where are you?", "i love you", "huh?", "puppy puppy", "puppy dog", "i can't see you", "come out", "i miss you" };
    public Font myFont;
    public GameObject renderCanvas;
    public string phrase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            rightOrLeft = (Random.value < 0.5);

            if (rightOrLeft == true) // Instantiate the object on the right
            {
                Text tempTextBox = Instantiate(textObject, new Vector3(Random.Range(-350, -275), Random.Range(-190, 150), 0), Quaternion.identity);
                tempTextBox.transform.SetParent(renderCanvas.transform, false);
                tempTextBox.fontSize = 10;
                tempTextBox.GetComponent<Text>().font = myFont;
                tempTextBox.text = dialogue[Random.Range(0, dialogue.Length)];
            }

            else // Instantiate the object on the left
            {
                Text tempTextBox = Instantiate(textObject, new Vector3(Random.Range(350, 450), Random.Range(-190, 150), 0), Quaternion.identity);
                tempTextBox.transform.SetParent(renderCanvas.transform, false);
                tempTextBox.fontSize = 10;
                tempTextBox.GetComponent<Text>().font = myFont;
                tempTextBox.text = dialogue[Random.Range(0, dialogue.Length)];
            }
            timer = textCooldown;
        }
    }

    public void Exclaim()
    {
        rightOrLeft = (Random.value < 0.5);

        if (rightOrLeft == true) // Instantiate the object on the right
        {
            Text tempTextBox = Instantiate(textObject, new Vector3(Random.Range(0, 1920), Random.Range(0, 1080), 0), Quaternion.identity);
            tempTextBox.transform.SetParent(renderCanvas.transform, false);
            tempTextBox.fontSize = 20;
            tempTextBox.GetComponent<Text>().font = myFont;
            tempTextBox.text = phrase;
        }

        else // Instantiate the object on the left
        {
            Text tempTextBox = Instantiate(textObject, new Vector3(Random.Range(350, 450), Random.Range(-190, 150), 0), Quaternion.identity);
            tempTextBox.transform.SetParent(renderCanvas.transform, false);
            tempTextBox.fontSize = 20;
            tempTextBox.GetComponent<Text>().font = myFont;
            tempTextBox.text = phrase;
        }
        timer = textCooldown;
    }
}
