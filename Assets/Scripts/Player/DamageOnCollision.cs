using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 1; // Damage dealt by the collision
    [SerializeField] private string _applyDamageToTag; // Tag that the gameObject to be damaged should have
    [SerializeField] private bool _destroyOnCollision = true; // This is true if the gameObject is to be destroyed on collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the gameObject attached to the collider that this gameObject is entering, has the given tag, try to damage it
        if (collision.gameObject.CompareTag(_applyDamageToTag))
        {
            TryDamage(collision);
        }
    }

    // This function tries to deal damage to the Health component attached to the collider's gameObject
    private void TryDamage(Collider2D collision)
    {
        // Try and see if the gameObject has a Health component, if it does, call its Damage function
        if (collision.TryGetComponent(out Health targetHealth))
            targetHealth.Damage(_damage);

        // Destroy gameObject if variable is true
        if (_destroyOnCollision) Destroy(gameObject);
    }
}
