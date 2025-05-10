using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Reference to the background music AudioSource

    private void Start()
    {
        // Play background music if assigned
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the trigger! Restarting...");
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
