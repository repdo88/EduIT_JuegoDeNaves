using System.Collections;
using System.Collections.Generic;
using TMPro; // Ensure you have TextMeshPro package installed for UI text
using UnityEngine;

public class ReadLastScore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI lastScoreText; // Reference to the TextMeshProUGUI component for displaying the last score
    // Start is called before the first frame update
    //void OnEnable()
    //{
    //    DisplayLastScore(); // Call the method to display the last score when the script starts
    //}

    public void DisplayLastScore()
    {
        ScoreEntry lastScore = LoadLastScore(); // Load the last score
        if (lastScoreText != null)
        {
            lastScoreText.text = //"Your Score\n" +
                                 //$"{lastScore.playerName}\n" +
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
}
