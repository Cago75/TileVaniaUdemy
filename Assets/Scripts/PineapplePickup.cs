using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineapplePickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(this.gameObject);
        }    
    }
}
