using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; // Singleton instance
    [SerializeField] private int lives = 3; // Number of lives
    public UnityEvent onDead; // Event to trigger when the player is dead

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
        if (lives > 1)
        {
            lives--; // Decrease the number of lives
            print("Lose live");
        }
        else
        {
            onDead.Invoke(); // Trigger the event when the player is dead
        }
    }


}
