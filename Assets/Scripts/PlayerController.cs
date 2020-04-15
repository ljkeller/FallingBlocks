using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 6;

    public float health;

    public float score;

    float screenHalfWidthInWorldUnits;

    BoxCollider2D myBoxCollider2d;

    Vector2 velocity;

    public event Action onPlayerDeath;

    public event Action onPointEarned;

    void Start()
    {
        myBoxCollider2d = GetComponent<BoxCollider2D>();
        float halfPlayerWdith = myBoxCollider2d.transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWdith;
        myBoxCollider2d.transform.position = new Vector2(0, -3);
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        velocity = direction * speed;
        

        //transform.position += moveAmount;
        
    }

    private void FixedUpdate()
    {
        Vector2 moveAmount = velocity * Time.deltaTime;
        transform.Translate(moveAmount);

        if (outOfBounds(transform.position))
        {
            if (transform.position.x < -screenHalfWidthInWorldUnits)
            {
                transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            score++;
            if(onPointEarned != null)
            {
                onPointEarned();
            }
            Destroy(collision.gameObject);
        } else if(collision.CompareTag("Enemy"))
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

    bool outOfBounds(Vector3 position)
    {
        return (position.x < -screenHalfWidthInWorldUnits) || (position.x > screenHalfWidthInWorldUnits);
    }
}
