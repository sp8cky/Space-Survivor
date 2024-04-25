using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Singleton instance of the GameManager for easy access from anywhere in the game 
    public static GameManager instance;
    public UIManager uiManager;
    private int score = 0;

    void Awake() {
        // Create singleton-instanz
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void PlayerDied() {
        Debug.Log("Player died!");
        RestartLevel();
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
}