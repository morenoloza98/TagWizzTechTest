using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _lifetime = 5f; // When this time has elapsed, destroy the game object

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
