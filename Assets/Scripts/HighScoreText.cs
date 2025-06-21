using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextHighScore; // Reference to the TextMeshProUGUI component for displaying the last score

    // Start is called before the first frame update
    void OnEnable()
    {
        DisplayMessage(); // Call the method to display the last score when the script starts
    }

    private void DisplayMessage()
    {
        int top = PlayerPrefs.GetInt("LastScoreInTop", 0); // Get the last score rank
        int rank = PlayerPrefs.GetInt("LastScoreRank", 0); // Get the last score rank

        if (top == 0)
        {
            TextHighScore.text = "You are not in the top 5!"; // Display message if the score is not in the top 5
        }
        else
        {
            TextHighScore.text = $"You are in the top {rank}"; // Display message with rank and score
        }
    }




}
