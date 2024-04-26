using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Singleton instance of the GameManager for easy access from anywhere in the game 
    public static GameManager instance;
    public UIManager uiManager;
    private int score = 0;
    private int highScore = 0;
    

    void Awake() {
        // Create singleton-instanz
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void PlayerDied() {
        Debug.Log("Player died!");
        UpdateHighScore();
        MenuController.instance.LoadGameOverScene(); //RestartLevel();
    }

    // Restarting level
    void RestartLevel() {
        Debug.Log("RestartLevel()");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Increase score method
    public void IncreaseScore(int amount) {
        score += amount;
        uiManager.UpdateScoreText(score);
    }

    // Get current score method (optional)
    public int GetScore() {
        return score;
    }

    // Check and update high score
    void UpdateHighScore() {
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score to PlayerPrefs
            PlayerPrefs.Save(); // Save PlayerPrefs
            uiManager.UpdateHighScoreText(highScore); // Update UI with new high score
        }
    }

    public int GetHighScore() {
        return highScore;
    }
}