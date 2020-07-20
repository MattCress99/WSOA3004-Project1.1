using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motor : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 7f;
    public Vector3 mousePosition;
    private Vector2 direction;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void zFix()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }


    void Motion()
    {
        if (Input.GetMouseButton(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed * 2, direction.y * speed * 2);
        }
        
        zFix();

        if(Vector3.Distance(transform.position,mousePosition) < 0.5f)
        {
            rb.velocity = Vector2.zero;
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
    }
}
