using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void AddScore(int points)
    {
        score += points; // Increase the score by the specified points
        Debug.Log("Score: " + score); // Log the current score
    }
}
