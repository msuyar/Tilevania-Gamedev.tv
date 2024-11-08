using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int pointAward = 50;
    PlayerMovement player;
    bool wasCollected = false;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }


    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !wasCollected)
        {
            FindObjectOfType<GameSession>().implementScore(pointAward);
            wasCollected = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "Big Enemy" && !wasCollected)
        {
            FindObjectOfType<GameSession>().implementScore(pointAward*2);
            wasCollected = true;
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
