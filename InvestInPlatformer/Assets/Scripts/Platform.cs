using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10F;
    GameManager gm;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

                PlayBoingSound();
            }
        }


    }

    void PlayBoingSound()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.PlaySound("boing");
    }
    void Update()
    {
        if (transform.position.y < player.GetComponent<Rigidbody2D>().transform.position.y - 5)
        {
            Debug.Log("hello");
            Destroy(gameObject);
        }
    }
}
