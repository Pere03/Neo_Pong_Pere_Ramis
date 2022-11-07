using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PR_Ball : MonoBehaviour
{
    public float speed = 15;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos,
                float paddleHeight)
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
    }

}
