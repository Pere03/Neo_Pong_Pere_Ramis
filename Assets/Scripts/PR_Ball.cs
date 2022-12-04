using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PR_Ball : MonoBehaviour
{
    public float speed = 15;
    public PR_GameManager Game_manager;
    public GameObject Text_P1;
    public GameObject Text_P2;
    public GameObject Text_L;
    public bool Madness;

    public AudioClip Ball;
    public AudioClip Point;
    public AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();

        Text_P1.SetActive(false);
        Text_P2.SetActive(false);
        Text_L.SetActive(false);

        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    private void Update()
    {
        //This means that if the "madness" condition is active, it will cause the speed of the ball to increase as time progresses.
        if (Madness == true)
        {
            if (Game_manager.timeValue <= 100 && Game_manager.timeValue >= 80)
            {
                speed = 15;
            }

            if (Game_manager.timeValue <= 80 && Game_manager.timeValue >= 50)
            {
                speed = 20;
            }

            if (Game_manager.timeValue <= 50 && Game_manager.timeValue >= 20)
            {
                speed = 25;
            }

            if (Game_manager.timeValue <= 20 && Game_manager.timeValue >= 0)
            {
                speed = 30;
            }
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Here we make that when the ball collides with a game object with the tag of Player 1 or Player 2 (the 2 rackets), it will bounce and go to the other direction, and depending on which part of the racket hits the ball, it will go up or down.
        if (col.gameObject.name == "Player1")
        {
            aSource.PlayOneShot(Ball);

            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Player2")
        {
            aSource.PlayOneShot(Ball);

            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //When the ball collides with the wall behind the rackets, it will add a point to the player who scored that point. In addition, it will show the points counter on the screen and you will see how this new point is added.
        if (col.gameObject.name == "Wall_Player2")
        {
            aSource.PlayOneShot(Point);

            EnableScore();
            Invoke("AddPlayer1", 0.5f);
            Invoke("DisableScore", 1);

        }

        if (col.gameObject.name == "Wall_Player1")
        {
            aSource.PlayOneShot(Point);

            EnableScore();
            Invoke("AddPlayer2", 0.5f);
            Invoke("DisableScore", 1);
        }
    }

    public void AddPlayer1()
    {
        Game_manager.AddPoint_Player1();
    }

    public void AddPlayer2()
    {
        Game_manager.AddPoint_Player2();
    }

    public void EnableScore()
    {
        Text_P1.SetActive(true);
        Text_P2.SetActive(true);
        Text_L.SetActive(true);
    }

    public void DisableScore()
    {
        Text_P1.SetActive(false);
        Text_P2.SetActive(false);
        Text_L.SetActive(false);
    }
}
