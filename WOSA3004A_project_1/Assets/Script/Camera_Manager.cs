using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float PanSpeed = 20f;
    public float BorderThick = 10f;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Motion()
    {
        Vector3 pos = transform.position;
        if(Input.mousePosition.y >= Screen.height - BorderThick)
        {
            pos.y += PanSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.y <= BorderThick)
        {
            pos.y -= PanSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x >= Screen.width - BorderThick)
        {
            pos.x += PanSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x <= BorderThick)
        {
            pos.x -= PanSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void follow()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Motion();
        follow();
    }
}
