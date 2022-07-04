using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _pellets = 3; // amount of projectiles that should be instantiated
    [SerializeField] private float _spreadAngle = 15f; // angle of the projectiles

    protected override void Shoot()
    {
        for (int i = 0; i < _pellets; i++)
        {
            // obtain the angle on which each projectile should be instantiated
            float angle = (i * _spreadAngle / (_pellets - 1)) - (_spreadAngle * 0.5f);
            // Calculate the rotation of the projectile using the previously calculated angle
            Quaternion forward = Quaternion.Euler(0, 0, angle) * transform.rotation;
            Instantiate(_bulletPrefab, transform.position, forward); // instantiate the projectile with the calculated rotation
        }
    }

    // This function is used to increase the fire rate when a power is used
    public override void SetFireRate(float value)
    {
        base.SetFireRate(value);
    }
}
