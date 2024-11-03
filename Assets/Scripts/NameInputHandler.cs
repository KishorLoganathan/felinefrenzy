using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInputHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject nameInputUI; 
    public GoalTrigger goalTrigger;    
    public bool hasSubmitted = false; 

    void Start() {

        nameInputField.onValueChanged.RemoveAllListeners();
        nameInputField.onValueChanged.AddListener(OnNameInputChanged);
    }


    private void OnNameInputChanged(string input) {

        if (input.Length == 3 && !hasSubmitted) {
            SubmitName();
        }
    }

    public void SubmitName() {
        
        if (hasSubmitted) return;
        hasSubmitted = true;

        string playerName = nameInputField.text.ToUpper();  // Converts name to uppercase

        // Add the player's name and time to the leaderboard
        LeaderboardData.completionEntries.Add(new LeaderboardData.LeaderboardEntry(playerName, goalTrigger.levelTimer.ElapsedTime));


        nameInputUI.SetActive(false);
        goalTrigger.ProceedToNextScene();


        Debug.Log($"Player name '{playerName}' submitted.");
    }
}
