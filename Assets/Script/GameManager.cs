using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinUI;
    private bool isGameOver = false;
    private bool isGameWin = false;

    void Start()
    {
        UpdateScore();
        gameOverPanel.SetActive(false); // Hide the game over panel at the start
        gameWinUI.SetActive(false); // Hide the game win UI at the start
    }

    // Update is called once per framef

    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateScore();
        }


    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0f; // Pause the game
        gameOverPanel.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0f; // Pause the game
        gameWinUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("Game"); // Reload the current scene
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu"); // Load the menu scene
        Time.timeScale = 1; // Ensure the game is resumed when going to the menu
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
