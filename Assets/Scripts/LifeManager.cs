using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance; // Singleton instance
    [SerializeField] private int lives = 3; // Number of lives

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
        if (lives > 0)
        {
            lives--; // Decrease the number of lives
            print("Lose live");
        }
        else
        {
            Debug.Log("Game Over!"); // Handle game over logic here
        }
    }


}
