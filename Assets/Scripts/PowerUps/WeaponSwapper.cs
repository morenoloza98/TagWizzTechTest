using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapper : PowerUp
{
    [SerializeField] private bool _isBaseWeapon; // check if power up prefab is the base weapon swapper

    // When the collider entered is the player's, toggle the weapons
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (collision.TryGetComponent(out PowerUpManager manager))
        {
            if (_isBaseWeapon) manager.ActivateBaseCannon();
            else manager.ActivateTriShot();
            Destroy(gameObject);
        }
    }
}
