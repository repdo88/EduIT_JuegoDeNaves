using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ReadScores;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    private int score = 0; // Player's score
    private int timePlayed = 0; // Time played in seconds
    private bool isAlive = true; // Flag to check if the game is active

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Assign the instance
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        StartCoroutine(CountingTime()); // Start the coroutine to count time played
    }

    private IEnumerator CountingTime()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timePlayed++; // Increase the time played by 1 second
            //Debug.Log("Time Played: " + timePlayed + " seconds"); // Log the time played
        }
    }

    public void finishTime()
    {
        isAlive = false; // Stop the game
        Debug.Log("Game Over! Final Score: " + score + ", Time Played: " + timePlayed + " seconds"); // Log final score and time played

        SaveLastScore(PlayerPrefs.GetString("PlayerName", "Unknown"), score, timePlayed); // Save the last score with player name and time played
        SaveHighScores(PlayerPrefs.GetString("PlayerName", "Unknown"), score, timePlayed); // Save the high scores with player name, score, and time played

    }

    public void AddScore(int points)
    {
        score += points; // Increase the score by the specified points
        Debug.Log("Score: " + score); // Log the current score
    }

    private void SaveLastScore(string name, int points, int time)
    {
        PlayerPrefs.SetString("LastPlayerName", name); // Save the player's name
        PlayerPrefs.SetInt("LastScore", points); // Save the last score
        PlayerPrefs.SetInt("LastTimePlayed", time); // Save the last time played
        PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
    }

    public void SaveHighScores(string name, int points, float time)
    {
        
        List<ScoreEntry> list = new List<ScoreEntry>();
        for (int i = 0; i < 5; i++)
        {
            string keyName = $"HighName{i}";
            int keyPoints = PlayerPrefs.GetInt($"HighPoints{i}", -1);
            float keyTime = PlayerPrefs.GetFloat($"HighTime{i}", 0f);
            if (keyPoints >= 0)
            {
                list.Add(new ScoreEntry(
                    PlayerPrefs.GetString(keyName, "—"),
                    keyPoints,
                    keyTime
                ));
            }
        }

        
        list.Add(new ScoreEntry(name, points, time));

        
        list = list.OrderByDescending(e => e.points)
                   .ThenBy(e => e.duration)       
                   .Take(5)
                   .ToList();

        
        for (int i = 0; i < list.Count; i++)
        {
            PlayerPrefs.SetString($"HighName{i}", list[i].playerName);
            PlayerPrefs.SetInt($"HighPoints{i}", list[i].points);
            PlayerPrefs.SetFloat($"HighTime{i}", list[i].duration);
        }

        PlayerPrefs.Save();
    }


}
