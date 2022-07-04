using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDestroyer : MonoBehaviour
{
    public UnityEvent OnDeath; // Event to be called when the player is killed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if a gameObject with tag Alien enters the player's collider, call/invoke the OnDeath event and destroy the player
        if (collision.gameObject.CompareTag("Alien"))
        {
            OnDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
