using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    Game_Manager GM;
    float counter = 0;
    float MaxTime;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        MaxTime = GM.ReturnTime();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GM.GameWin();
        }
    }

    void SickoMode()
    {
        counter = GM.ReturnTime();

        transform.Rotate(new Vector3(0f, 0f, 360 * Time.deltaTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(4,4,1), counter / MaxTime);
    }
    void Update()
    {
        SickoMode();
    }
}
