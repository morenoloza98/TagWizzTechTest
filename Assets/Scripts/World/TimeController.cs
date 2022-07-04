using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // On Start, set the time scale to normal
    private void Start()
    {
        Time.timeScale = 1f;    
    }

    // Stop time
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }
}
