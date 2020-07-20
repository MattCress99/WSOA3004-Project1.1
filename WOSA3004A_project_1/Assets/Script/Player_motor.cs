using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    float _speed = 10f;
    void Start()
    {
        
    }

    void zFix()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }


    void Motion()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        zFix();
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
