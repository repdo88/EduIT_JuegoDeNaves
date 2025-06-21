using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; // Singleton instance
    [SerializeField] private int lives = 3; // Number of lives
    public UnityEvent onDead; // Event to trigger when the player is dead
    [SerializeField] private GameObject life1; // Reference to the first life GameObject
    [SerializeField] private GameObject life2; // Reference to the second life GameObject

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



    public void LoseLife()
    {
        if (lives > 2)
        {
            life1.SetActive(false);
            lives--; // Decrease the number of lives
            print("Lose live");
        }
        else if (lives > 1)
        {
            life2.SetActive(false);
            lives--; // Decrease the number of lives
            print("Lose live");
        }
        else
        {
            onDead.Invoke(); // Trigger the event when the player is dead
        }
    }


}
