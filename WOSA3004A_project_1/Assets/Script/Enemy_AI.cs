using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject reference;
    float GCD;
    float counter;
    public float Range;
    Vector3 CurrentPosition;
    Vector3 NextPosition;
    Game_Manager GM;
    bool StartMotion = false;
    Vector2 Direction;
    Rigidbody2D rb;
    public float speed;
    public GameObject Radius;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        GCD = Random.Range(1, 4);
        Debug.Log("GCD :" + GCD);
        rb = GetComponent<Rigidbody2D>();
        CurrentPosition = transform.position;
        if(Radius != null)
        {
            Radius.transform.localScale = new Vector3(Range * 2, Range * 2, 1);
        }
      
    }



    void Motion()
    {
        counter += Time.deltaTime;
        if(counter >= GCD)
        {
            StartMotion = true;
            counter = 0;
            CurrentPosition = transform.position;
            NextPosition = new Vector3(transform.position.x, transform.position.y + 10, 0);
            while(Vector3.Distance(reference.transform.position,NextPosition) > Range)
            {
                float TempX = Random.Range(-4, 4);
                float TempY = Random.Range(-4, 4);
                Debug.Log("TempX: " + TempX + " TempY: " + TempY);
                NextPosition = new Vector3(transform.position.x + TempX, transform.position.y + TempY, 0);
                Direction = (NextPosition - CurrentPosition).normalized;
                Debug.Log(Direction);
                rb.velocity = Direction * speed;

            }

           

        }
        if(StartMotion == true)
        {
           // transform.position = Vector3.Lerp(CurrentPosition, NextPosition, counter / GCD * 2);
        }
    }
       
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // rb.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
