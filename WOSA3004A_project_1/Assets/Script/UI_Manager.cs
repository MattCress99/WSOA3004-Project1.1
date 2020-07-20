using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Counter;
    public GameObject GameOverText;
    
    void Start()
    {
        GameOverText.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
