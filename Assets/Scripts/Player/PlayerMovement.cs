using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10; // value to multiply the input value direction
    [SerializeField] private Camera _mainCamera; // save a reference to the main camera if possible to avoid using Camera.main as it is expensive

    private float _horizontalDirection; // The value the input axis will return
    private Rigidbody2D _rb; // This gameObject's rigidbody2D

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>(); // Get the rigidbody on awake to perform actions on it

        if (_mainCamera == null) _mainCamera = Camera.main; // In case it was not possible to assign the reference from inspector, look for it
    }

    void FixedUpdate()
    {
        _horizontalDirection = Input.GetAxis("Horizontal") * _speed; // multiply the input axis value times the speed

        Vector3 targetVelocity = new Vector2(_horizontalDirection, 0); // The velocity to be applied to the rigidbody to move the object

        _rb.velocity = targetVelocity; // Assing said target velocity to this gameObject's rigidbody

        ClampPositionToViewport();
    }
    
    // Lock the player's movement area to the main camera's viewport.
    private void ClampPositionToViewport()
    {
        // Convert world position into viewport point
        Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);

        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.05f, 0.95f);

        transform.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
    }
}
