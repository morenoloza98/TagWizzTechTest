using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; // Speed with which the projectile will travel through the world
    [SerializeField] private bool _isTimeToDestroy = false; // if there is a lifetime for the projectile, set this to true
    [SerializeField] private float _lifetime = 10f; // The time of life the gameObject has

    private Rigidbody2D _rb; // gameObject's rigidbody2D reference

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.up; // set the rigidbody's velocity to the speed times the up vector of the transform

        // if there is a lifetime for the gameObject to be destroyed, do it
        if (_isTimeToDestroy)
        {
            Destroy(gameObject, _lifetime);
        }
    }
}
