using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Set in the player's preferences the level to be loaded chosen by the player in the Menu scene
    public void SetLevelNumber(int value)
    {
        PlayerPrefs.SetInt("LevelToLoad", value);
    }
}
