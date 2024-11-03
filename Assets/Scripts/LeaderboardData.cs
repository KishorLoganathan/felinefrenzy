using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardData
{

    public class LeaderboardEntry {
        public string playerName;
        public float playerCompletionTime;

        public LeaderboardEntry (string name, float time) {

            playerName = name;
            playerCompletionTime = time;
        }
    }
    public static List<LeaderboardEntry> completionEntries = new List<LeaderboardEntry>();
    
}

