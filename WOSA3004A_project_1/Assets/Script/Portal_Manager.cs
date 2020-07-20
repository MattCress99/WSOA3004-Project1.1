using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    Game_Manager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GM.GameWin();
        }
    }
    void Update()
    {
        
    }
}
