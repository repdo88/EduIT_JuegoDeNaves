using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_InputField playerNameInputField; // Reference to the TMP_InputField component

    private string playerName; // Variable to store the player's name

    public void onNameEntered(string input)
    {
        playerName = input; // Store the player's name from the input field
        Debug.Log("Player Name Entered: " + playerName); // Log the entered name for debugging
        PlayerPrefs.SetString("PlayerName", playerName); // Save the player's name to PlayerPrefs
        PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved
    }

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName", ""); // Retrieve the player's name from PlayerPrefs, defaulting to an empty string if not set
        playerNameInputField.text = playerName; // Set the input field text to the retrieved player name
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
