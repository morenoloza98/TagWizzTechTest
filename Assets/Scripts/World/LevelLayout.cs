using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLayout : MonoBehaviour
{
    [SerializeField] private GameObject[] _aliens; // Options of the gameObjects to be spawned for the level
    [SerializeField] private int _rows = 4; // Amount of rows of gameObjects to be instantiated 
    [SerializeField] private int _columns = 8; // Amount of columns of gameObjects to be instantiated
    [SerializeField] private float _speed; // Speed of the gameObjects' movement from side to side
    [SerializeField] private float _screenHeight; // The height of the screen
    [SerializeField] private Camera _mainCamera; // A reference to the main camera to avoid using Camera.main

    private Vector3 _direction = Vector3.right; // Initial direction for the gameObjects' movement

    public UnityEvent OnWin; // Unity event to be called when the player beats the level

    private void Awake()
    {
        if (_mainCamera != null) _mainCamera = Camera.main; // If it was not possible to get the reference from inspector, look for it

        // Load the level depending on the player's choice in the Menu scene
        switch (PlayerPrefs.GetInt("LevelToLoad"))
        {
            case 1:
                BuildGridLayout();
                break;
            case 2:
                BuildBrickwallLayout();
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.fixedDeltaTime; // Enemies' movement

        Vector3 leftEdge = _mainCamera.ViewportToWorldPoint(Vector3.zero); // Reference to the camera's viewport's left edge
        Vector3 rightEdge = _mainCamera.ViewportToWorldPoint(Vector3.right); // Reference to the camera's viewport's right edge

        // For each enemy, check if they are already on the camera's edge and call the MoveDown function
        foreach (Transform alien in transform)
        {
            if (_direction == Vector3.right && alien.position.x >= (rightEdge.x - 0.95f))
            {
                MoveDown();
            } else if (_direction == Vector3.left && alien.position.x <= (leftEdge.x + 0.95f))
            {
                MoveDown();
            }
        }

        CheckIfPlayerWon();
    }

    // Flip enemies direction and move them down a row
    private void MoveDown()
    {
        _direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    // Instantiate enemies in a grid layout
    private void BuildGridLayout()
    {
        _speed = 0.75f;
        _screenHeight = 1.9f;

        for (int i = 0; i < _rows; i++)
        {
            float width = 1f * (_columns - 1);
            float height = 1f * (_rows - 1);

            Vector3 centering = new Vector2(-width / 2, -height / 6);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (i * 1f), 0.0f);

            for (int j = 0; j < _columns; j++)
            {
                GameObject alien = Instantiate(_aliens[Random.Range(0, _aliens.Length)], transform.position, transform.rotation);
                Vector3 position = rowPosition;
                position.x += j * 0.95f;
                alien.transform.localPosition = position;
                alien.transform.parent = gameObject.transform;
            }
        }

        Vector3 gridPosition = new Vector3(transform.localPosition.x, _screenHeight, 0);
        transform.localPosition = gridPosition;
    }

    // Instantiate enemies in a brick wall layout
    private void BuildBrickwallLayout()
    {
        _speed = 0.85f;
        for (int i = 0; i < _columns; i++)
        {
            float width = 1f * (_columns - 1);
            float height = 1f * (_rows - 1);

            Vector3 centering = new Vector2(-width / 2, -height / 2);

            for (int j = 0; j < _rows; j++)
            {
                GameObject alien = Instantiate(_aliens[Random.Range(0, _aliens.Length)]);
                float offset = j % 2;

                alien.transform.localPosition = new Vector3(centering.x + transform.position.x + i * 1 + offset, centering.y + transform.position.y + j + 1.5f, 0);
                alien.transform.parent = gameObject.transform;
            }
        }
    }

    // Check if there are still gameObjects with the Alien tag (enemies), if not, invoke/call the win event
    public void CheckIfPlayerWon()
    {
        if (GameObject.FindGameObjectWithTag("Alien") == null) OnWin.Invoke();
    }
}
