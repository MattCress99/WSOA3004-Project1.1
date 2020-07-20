using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    float Timer = 0;
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
        Timer += Time.deltaTime;
        UIM.UISetCounter((int)Timer);
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
    }
}
