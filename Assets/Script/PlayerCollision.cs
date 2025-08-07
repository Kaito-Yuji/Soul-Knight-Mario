using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager; // Reference to the AudioManager script
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>(); // Find the AudioManager in the scene

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
          
    // Reference to the GameManager script to handle score and game state
           if (collision.CompareTag("Coin"))
           {
                Destroy(collision.gameObject); // Destroy the coin object
                audioManager.PlayCoinSound(); // Play coin sound using AudioManager
                gameManager.AddScore(1); 
           }
           else if (collision.CompareTag("Trap"))
           {
                gameManager.GameOver(); // Call GameOver method in GameManager
           }
           else if (collision.CompareTag("Enemy"))
           {
                gameManager.GameOver(); // Call GameOver method in GameManager
           }
           else if (collision.CompareTag("Key"))
           {
               Destroy(collision.gameObject); // Destroy the key object
                gameManager.GameWin(); // Call GameWin method in GameManager
           }
    }

}
