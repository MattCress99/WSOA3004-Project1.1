using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float Timer;
    bool StopTime = false;
    UI_Manager UIM;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void TimerCount()
    {
        if(StopTime == false)
        {
            Timer -= Time.deltaTime;
            UIM.UISetCounter((int)Timer);
            if(Timer <= 0)
            {
                Timer = 0;
                GameOver();
            }
        }
        
    }

    public void GameWin()
    {
        StopTime = true;
        UIM.SetGameOverText("You win! With a time of " + Timer + " Seconds!");
    }

    private void ResetGame()
    {
        if(StopTime == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
        ResetGame();
    }
}
