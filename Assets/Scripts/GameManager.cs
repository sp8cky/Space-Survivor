using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance; 
    private float score;
    private float highScore;
    private float playerMaxHealth = 10;
    private float currentPlayerHealth;
    
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
        currentPlayerHealth = playerMaxHealth;
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load high score from PlayerPrefs
        UIManager.instance.UpdateHighScoreText(highScore);
    }

    // HEALTH //////////////////////////////////////////////////////////////////////////////
    public float GetPlayerCurrentHealth() { return currentPlayerHealth; }
    public float GetPlayerMaxHealth() { return playerMaxHealth; }

    public void IncreasePlayerHealth(float amount) {
        currentPlayerHealth += amount;
        if (currentPlayerHealth > playerMaxHealth) currentPlayerHealth = playerMaxHealth;
        UIManager.instance.UpdatePlayerHealthText(currentPlayerHealth);
    }

    public void DecreasePlayerHealth(float amount) {
        currentPlayerHealth -= amount;
        UIManager.instance.UpdatePlayerHealthText(currentPlayerHealth);
        if (currentPlayerHealth <= 0) {
            PlayerDied();
            UIManager.instance.UpdatePlayerHealthText(currentPlayerHealth);
        }
    }
    
    // Player died when health is 0
    public void PlayerDied() {
        Debug.Log("Player died!");
        UpdateHighScore();
        MenuController.instance.LoadGameOverScene(); 
    }

    // SCORE //////////////////////////////////////////////////////////////////////////////
    public float GetPlayerHighScore() { return highScore; }

    // Increase score method
    public void IncreaseScore(float amount) {
        score += amount;
        UIManager.instance.UpdateScoreText(score);
    }

    // Check and update high score
    void UpdateHighScore() {
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", (int)highScore); // Save high score to PlayerPrefs
            PlayerPrefs.Save(); // Save PlayerPrefs
            UIManager.instance.UpdateHighScoreText(highScore); // Update UI with new high score
        }
    }
   

    
}