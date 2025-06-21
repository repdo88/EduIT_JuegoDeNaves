using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamOverActivate : MonoBehaviour
{
    public static GamOverActivate Instance;
    public UnityEvent onGameOver; // Event to trigger when the game is over



    

    // Start is called before the first frame update
    void OnEnable()
    {
        onGameOver.Invoke(); // Invoke the game over event at the start
    }

    
}
