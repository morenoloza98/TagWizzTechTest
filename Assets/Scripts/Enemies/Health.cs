using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float _maxHealth = 1; // Maximum amount of health
    [SerializeField] private PowerUp[] _powerUps; // Power up options to spawn when killed

    [Header("Score")]
    [SerializeField] private int _scoreValue = 0; // Amount of score killing this will grant the player

    private int _multiplier; // Calculated value according to distance from the gameObject attached from middle of screen

    private float _currentHealth; // Health remaining

    private void Start()
    {
        _currentHealth = _maxHealth; // When object is spawned, set its current health to the max health it has
    }

    // Reduce the amount of damage passed as a parameter (int) to the current health
    public void Damage(int amount)
    {
        if (_currentHealth <= 0) return; // if the currrent health is less than or zero, do not do the following calculations

        // Set new health with the calculation of the current health minus the amount and clamp it
        float newHealth = _currentHealth - amount; 
        _currentHealth = Mathf.Clamp(newHealth, 0f, _maxHealth);

        // if the current health is less than or zero, calculate the multiplier for the score and add that score; 
        // spawn a power up and destroy gameObject
        if (_currentHealth <= 0)
        {
            CalculateDistanceMultiplier();
            Score.AddScore(_scoreValue * _multiplier);
            SpawnPowerUp();
            Destroy(gameObject);
        }
    }

    // Get the middle of the world, then calculate the distance between that point and this gameObject
    // and assign a value to the multiplier to calculate the score.
    private void CalculateDistanceMultiplier()
    {
        Vector3 middleOfScreen = Vector3.zero;

        Vector3 distanceToMiddle = middleOfScreen - transform.position;

        if (distanceToMiddle.y < 0)
        {
            _multiplier = 3;
        } 
        else
        {
            _multiplier = 1;
        }
    }

    // When the object has no health, there is a 20% chance it will spawn a random power up
    private void SpawnPowerUp()
    {
        float chance = Random.Range(0f, 1f);

        if (chance <= 0.79) return;

        int powerUp = Random.Range(0, _powerUps.Length);

        Instantiate(_powerUps[powerUp], transform.position, transform.rotation);
    }
}
