using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    private int score = 0; // Player's score

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

    public void AddScore()
    {
        score += 1; // Increase the score by the specified points
        Debug.Log("Score: " + score); // Log the current score
    }
}
