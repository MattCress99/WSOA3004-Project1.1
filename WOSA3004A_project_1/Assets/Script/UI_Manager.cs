using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Counter;
    public GameObject GameOverText;
    public GameObject PushNotif;
    public GameObject HighScore;
    float counter;
    void Start()
    {
        GameOverText.SetActive(false);
        HighScore.GetComponent<Text>().text = "HighScore: " + (int)PlayerPrefs.GetFloat("HighScore");
    }


    public void UISetCounter(int _counter)
    {
        Counter.GetComponent<Text>().text = "Counter: " + _counter;
    }

    public void SetGameOverText(string _message)
    {
        GameOverText.SetActive(true);
        GameOverText.GetComponent<Text>().text = _message;
    }

    void PushNote(string _Message)
    {
        PushNotif.GetComponent<Text>().text = _Message;
    }

    void StarterMessage()
    {
        counter += Time.deltaTime;
        if(counter < 2)
        {
            PushNote("Right click to move!");
        }else if (counter < 4)
        {
            PushNote("Get to center! Before timer runs out");
        }else if (counter < 6)
        {
           
            PushNote("Collect the Jordonz for speed!");
        }
        else if (counter < 8)
        {
            PushNotif.active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StarterMessage();
    }
}
