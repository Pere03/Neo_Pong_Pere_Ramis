using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PR_Ball_Madness : MonoBehaviour
{
    public float speed = 15;
    public PR_GameManager_Madness Game_manager;
    public GameObject Text_P1;
    public GameObject Text_P2;
    public GameObject Text_L;

    void Start()
    {
        Text_P1.SetActive(false);
        Text_P2.SetActive(false);
        Text_L.SetActive(false);

        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    private void Update()
    {
        
        if(Game_manager.timeValue <= 80 && Game_manager.timeValue >= 50)
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

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Player2")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.name == "Wall_Player2")
        {
            EnableScore();
            Invoke("AddPlayer1", 0.5f);
            Invoke("DisableScore", 1);

        }

        if (col.gameObject.name == "Wall_Player1")
        {
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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
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
