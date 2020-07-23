using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Portal : MonoBehaviour
{
    // Start is called before the first frame update
    Game_Manager GM;
    float counter = 0;
    float MaxTime;
    Vector3 StartScale;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        MaxTime = GM.ReturnTime();
        StartScale = transform.localScale;
    }

    void SickoMode()
    {
        counter = GM.ReturnTime();

        transform.Rotate(new Vector3(0f, 0f, 360 * Time.deltaTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, StartScale, counter / MaxTime);
    }
    // Update is called once per frame
    void Update()
    {
        SickoMode();
    }
}
