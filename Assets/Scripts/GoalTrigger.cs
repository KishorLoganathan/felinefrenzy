using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoalTrigger : MonoBehaviour
{
    
    public SceneFader sceneFader;
    public string levelToLoad;
    public bool isTransitioning = false;
    public LevelTimer levelTimer;
    public GameObject thirdCanvas;
    public TMP_InputField nameInputField;


    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player") && !isTransitioning) {

            Debug.Log("Player entered the goal");
            isTransitioning = true;

            if (levelTimer != null) {

                levelTimer.StopTimer();

            }

            if (thirdCanvas != null) {

                thirdCanvas.SetActive(true);

                // Focus the input field
                nameInputField.ActivateInputField();
                EventSystem.current.SetSelectedGameObject(nameInputField.gameObject, null);

                // Optionally log if the field is focused
                Debug.Log("Input Field is activated and focused.");

            } else {
                Debug.LogError("Third Canvas is not assigned");
            }
        }
    }

    public void ProceedToNextScene() {

        PlayerPrefs.SetString("NextScene", levelToLoad);

        if (sceneFader != null) {

            Debug.Log("Starting scene transition...");
            sceneFader.FadeToScene("LoadScene");

        } else {

            Debug.LogError("sceneFader is NOT assigned!");

        }
    }
}
