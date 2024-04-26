using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour {
    private PlayerController playerController;
    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        
        // Errorcatch
        if (playerController == null) Debug.LogWarning("UIManager: PlayerController not found");
        scoreText.text = "Score: 0";
        UpdateHighScoreText(GameManager.instance.GetHighScore());
    }

    void Update() {
        // Update the health display based on the player's current health points
        if (playerController != null) healthText.text = "Health: " + playerController.GetCurrentHealth().ToString();
    }

    // Update score and highscore text methods
    public void UpdateScoreText(int score) {
        scoreText.text = "Score: " + score.ToString();
    }
    public void UpdateHighScoreText(int highScore) {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}