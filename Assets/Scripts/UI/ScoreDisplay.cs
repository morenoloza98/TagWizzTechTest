using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLabel; // Reference to the score text in the UI

    private void Start()
    {
        Score.OnAddScoreEvent += SetScoreDisplay; // Subscribe to the event on start
        _scoreLabel.text = $"Score: {Score.ScoreVar}"; // Set the text value of the UI element
    }

    // Set the text of the UI element with the given score argument
    private void SetScoreDisplay(int score)
    {
        _scoreLabel.text = "Score: " + score.ToString();
    }

    // Unsubscribe to OnAddScore event on gameObject's destruction
    private void OnDestroy()
    {
        Score.OnAddScoreEvent -= SetScoreDisplay;
    }
}
