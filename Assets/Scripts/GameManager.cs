using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance; // Singleton instance of the GameManager for easy access from anywhere in the game 
    public UIManager uiManager;
    private int score;
    private int highScore;
    private int playerHealth;
    
    void Awake() {
        // Create singleton-instanz
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        score = 0;
        playerHealth = 3;
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score from PlayerPrefs
        uiManager.UpdateHighScoreText(highScore);
    }

    public void DecreasePlayerHealth(int amount) {
        playerHealth -= amount;
        if (uiManager != null) uiManager.UpdatePlayerHealthText(playerHealth);
        if (playerHealth <= 0) PlayerDied();
    }

    // Increase score method
    public void IncreaseScore(int amount) {
        score += amount;
        uiManager.UpdateScoreText(score);
    }

    public void IncreasePlayerHealth(int amount) {
        playerHealth += amount;
        if (uiManager != null) uiManager.UpdatePlayerHealthText(playerHealth);
    }

    // Getter
    public int GetPlayerScore() { return score; }
    public int GetPlayerHealth() { return playerHealth; }
    public int GetPlayerHighScore() { return highScore; }

    // Player died when health is 0
    public void PlayerDied() {
        Debug.Log("Player died!");
        UpdateHighScore();
        MenuController.instance.LoadGameOverScene(); 
    }
    
    // Restarting level
    void RestartLevel() {
        Debug.Log("RestartLevel()");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Check and update high score
    void UpdateHighScore() {
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score to PlayerPrefs
            PlayerPrefs.Save(); // Save PlayerPrefs
            if (uiManager != null) uiManager.UpdateHighScoreText(highScore); // Update UI with new high score
        }
    }
   

    
}