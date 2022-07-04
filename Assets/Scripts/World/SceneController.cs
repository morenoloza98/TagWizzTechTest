using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Load the scene with the given name and set the timescale to normal
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    // Quit the game
    public void Quit()
    {
        Application.Quit();
    }

    // Reset score
    public void ResetScoreAfterDeath()
    {
        Score.ResetScore();
    }
}
