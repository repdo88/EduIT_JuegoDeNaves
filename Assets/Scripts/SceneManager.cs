using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    [SerializeField] private GameObject gameOverCanvas; // Reference to the Game Over canvas

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwapToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void callStartGameOver()
    {
        StartCoroutine(startGameOver()); // Start the coroutine to handle Game Over
    }

    public IEnumerator startGameOver()
    {
        yield return new WaitForSeconds(0.01f); // Wait for 1 second before showing Game Over
        gameOverCanvas.SetActive(true); // Activate the Game Over canvas
        
    }
}
