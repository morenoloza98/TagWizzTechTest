using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject _baseWeapon; // Basic weapon gameObject reference
    [SerializeField] private GameObject _shotgun; // Shotgun weapon gameObject reference

    // When this function is called, try to get the Weapon component of the base weapon and increase its fire rate
    public void IncreaseFireRate()
    {
        if (_baseWeapon.TryGetComponent(out Weapon weapon))
        {
            weapon.SetFireRate(0.25f);
        }
    }

    // Activate the Shotgun Weapon GameObject and deactivate the Base one
    public void ActivateTriShot()
    {
        _baseWeapon.SetActive(false);
        _shotgun.SetActive(true);
    }

    // Activate the Base Weapon GameObject and deactivate the Shotgun 
    public void ActivateBaseCannon()
    {
        _shotgun.SetActive(false);
        _baseWeapon.SetActive(true);
    }
}
