using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineapplePickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] int pickupValue = 100;
    bool wasCollected;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            FindObjectOfType<GameSession>().AddToScore(pickupValue);
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(this.gameObject);
            wasCollected = true;
        }    
    }
}
