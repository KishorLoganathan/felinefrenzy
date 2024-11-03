using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Reference to the Text UI
    private float elapsedTime = 0f;    // Tracks the elapsed time
    private bool isTiming = true;      // Tracks whether the timer is running

    // Property to access the elapsed time
    public float ElapsedTime
    {
        get { return elapsedTime; }
    }

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this method to stop the timer
    public void StopTimer()
    {
        isTiming = false;
        Debug.Log("Time Stopped: " + elapsedTime + " seconds");
    }
}
