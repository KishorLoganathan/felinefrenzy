using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    public SceneFader sceneFader;

    // This will activate the UI for the pause menu
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (isPaused) {

                Resume();

            } else {

                Pause();
            }
        }
    }

    // If the game is already paused, pressing escape will activate this function.
    public void Resume() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // If the game is not paused, the UI will become visible
    public void Pause() {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = true;
    }

    // This will bring the player back to the main menu
    public void BackToMenu() {

        sceneFader.FadeToScene("MainMenu");

    }
}
