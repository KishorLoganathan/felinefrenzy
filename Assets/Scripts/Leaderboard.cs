using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class Leaderboard : MonoBehaviour
{
    
    public GameObject leaderboardUI;
    public GameObject rawImage;
    public GameObject MainPanel;
    public GameObject TitlePanel;
    public TextMeshProUGUI leaderboardText;

    void Start() {

        leaderboardUI.SetActive(false); // Sets the leaderboard section of the UI disabled

        if (LeaderboardData.completionEntries.Count > 0) {

            StringBuilder leaderboardBuilder = new StringBuilder();
            leaderboardBuilder.AppendLine("Leaderboard:");

            for (int i = 0; i < LeaderboardData.completionEntries.Count; i++) {

                var entry = LeaderboardData.completionEntries[i];

                // Convert the saved time into minutes and seconds
                int minutes = Mathf.FloorToInt(entry.playerCompletionTime / 60F);
                int seconds = Mathf.FloorToInt(entry.playerCompletionTime % 60F);

                leaderboardBuilder.AppendLine($"Run {i + 1}: {entry.playerName} - {minutes:00}:{seconds:00}");

            }

            leaderboardText.text = leaderboardBuilder.ToString();

        } else {

            leaderboardText.text = "No completion time yet.";

        }
    }

    // A fuction for a button component to use
    public void LeaderboardButtonClicked() {

        leaderboardUI.SetActive(true);
        rawImage.SetActive(false);
        MainPanel.SetActive(false);
        TitlePanel.SetActive(false);

    }

    // Another function for a button component to use
    public void LeaderboardBackButtonClicked() {

        leaderboardUI.SetActive(false);
        rawImage.SetActive(true);
        MainPanel.SetActive(true);
        TitlePanel.SetActive(true);

    }
}
