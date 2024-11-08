using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointAward = 100;
    bool wasCollected = false;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().implementScore(pointAward);
            wasCollected = true;
            Destroy(gameObject);
        }
        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }    
    }
   
}
