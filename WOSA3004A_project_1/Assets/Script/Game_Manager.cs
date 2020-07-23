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
    public GameObject MouseEffect;
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
    public float ReturnTime()
    {
        return Timer;
    }

    void Effect()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 Loc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Loc = new Vector3(Loc.x, Loc.y, 0);
            Instantiate(MouseEffect, Loc, Quaternion.identity);
        }
    }

    public void GameWin()
    {
        StopTime = true;
        UIM.SetGameOverText("You win! With a time of " + Timer + " Seconds! Press Space to restart!");
        if(Timer > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", Timer);
        }
        
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


    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
        ResetGame();
        Effect();
        QuitGame();
    }
}
