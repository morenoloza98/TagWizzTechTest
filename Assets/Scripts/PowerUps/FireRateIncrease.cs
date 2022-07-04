using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateIncrease : PowerUp
{
    // When the player's collider is entered, try to get its PowerUpManager component and call the IncreaseFireRate function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (collision.TryGetComponent(out PowerUpManager manager))
        {
            manager.IncreaseFireRate();
            Destroy(gameObject);
        }
    }
}
