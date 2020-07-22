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
    float TempX,TempY;
    Vector2 Direction;
    Rigidbody2D rb;
    public float speed;
    public GameObject Radius;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        GCD = Random.Range(1, 4);
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
                TempX = Random.Range(-4, 4);
                 TempY = Random.Range(-4, 4);
                NextPosition = new Vector3(transform.position.x + TempX, transform.position.y + TempY, 0);
                Direction = (NextPosition - CurrentPosition).normalized;
                rb.velocity = Direction * speed;
                Debug.Log(Mathf.Atan((transform.position.y + TempY / transform.position.x + TempX)));
               transform.Rotate(new Vector3(0f,0f,360*Mathf.Atan((transform.position.y + TempY / transform.position.x + TempX))));

            }

           

        }
        if(StartMotion == true)
        {
         
        }
    }
       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Direction = Direction * -1;
        rb.velocity = Direction * speed;
        transform.Rotate(new Vector3(0f, 0f, 360 * Mathf.Atan((transform.position.y + TempY / transform.position.x + TempX))));

    }
    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
