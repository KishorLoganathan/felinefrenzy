using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    
    public LevelTimer levelTimer;

    // A simple function to stop the timer
    void CompleteLevel() {
        levelTimer.StopTimer();
    }
}
