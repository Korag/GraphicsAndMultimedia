using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    // For now just destroy the coin if the player runs into
    // it. Could play a sound, add to a score or more here later
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Coin was picked up");
        }
    }
}
