using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you have TextMeshPro package installed for UI text

public class ReadScores : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI lastScoreText; // Reference to the TextMeshProUGUI component for displaying the last score
    [SerializeField] private TextMeshProUGUI highScoresText; // Reference to the TextMeshProUGUI component for displaying high scores


    private void Start()
    {
        DisplayLastScore(); // Call the method to display the last score when the script starts
        DisplayHighScores(); // Call the method to display high scores when the script starts
    }

    private void DisplayLastScore()
    {
        ScoreEntry lastScore = LoadLastScore(); // Load the last score
        if (lastScoreText != null)
        {
            lastScoreText.text = "Last Score\n" +
                                 $"{lastScore.playerName}\n" +
                                 $"{lastScore.points} points\n" + 
                                 $"{lastScore.duration:F2} seconds"; // Format and display the score
        }
        else
        {
            Debug.LogWarning("Last Score TextMeshProUGUI component is not assigned!"); // Log a warning if the text component is not assigned
        }
    }

    public class ScoreEntry
    {
        public string playerName;
        public int points;
        public float duration;

        public ScoreEntry(string name, int pts, float time)
        {
            playerName = name;
            points = pts;
            duration = time;
        }
    }

    public ScoreEntry LoadLastScore()
    {
        string name = PlayerPrefs.GetString("LastPlayerName", "—");
        int pts = PlayerPrefs.GetInt("LastScore", 0);
        float time = PlayerPrefs.GetInt("LastTimePlayed", 0);
        return new ScoreEntry(name, pts, time);
    }

    void DisplayHighScores()
    {
        List<ScoreEntry> top5 = LoadHighScores();

        if (top5 == null || top5.Count == 0)
        {
            highScoresText.text = "— No score registered —";
            return;
        }

        
        string info = "<b>Top 5:</b>\n";
        for (int i = 0; i < top5.Count; i++)
        {
            var entry = top5[i];
            info += $"{i + 1}. {entry.playerName} — {entry.points} pts — {entry.duration:F2} s\n";
        }

        highScoresText.text = info;
    }

    List<ScoreEntry> LoadHighScores()
    {
        List<ScoreEntry> list = new List<ScoreEntry>();
        for (int i = 0; i < 5; i++)
        {
            int keyPoints = PlayerPrefs.GetInt($"HighPoints{i}", -1);
            if (keyPoints < 0) break;

            string keyName = PlayerPrefs.GetString($"HighName{i}", "—");
            float keyTime = PlayerPrefs.GetFloat($"HighTime{i}", 0f);

            list.Add(new ScoreEntry(keyName, keyPoints, keyTime));
        }
        return list;
    }

}
