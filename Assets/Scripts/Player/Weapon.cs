using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shotCooldown = 0.2f; // Fire rate. Time to wait for next shot action
    [SerializeField] private KeyCode _inputOne = KeyCode.W; // Key code for the first input option to fire
    [SerializeField] private KeyCode _inputTwo = KeyCode.UpArrow; // Key code for the second input option to fire
    [SerializeField] protected Projectile _bulletPrefab; // Projectile script attached to the bullet prefab gameObject
    
    private float _nextShootTime; // Reference value to be calculated to know when the player is able to shoot again

    // Update is called once per frame
    void Update()
    {
        // If the player presses the keys to fire and it is time to shoot, call the Shoot function
        if ((Input.GetKeyDown(_inputOne) || Input.GetKeyDown(_inputTwo)) && Time.timeSinceLevelLoad >= _nextShootTime)
        {
            _nextShootTime = Time.timeSinceLevelLoad + _shotCooldown; // set the next time to shoot using the cooldown
            Shoot();
        }
    }

    // Class to be used by other Weapon objects to instantiate the bullet prefab.
    protected virtual void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }

    // Function to increase the fire rate when a power up is consumed
    public virtual void SetFireRate(float value)
    {
        if (_shotCooldown <= 0.25f) return;
        _shotCooldown -= value;
    }
}
