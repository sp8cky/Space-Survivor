using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour {
    public TMP_Text healthText;
    public TMP_Text scoreText;
    private PlayerController playerController;

    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        
        // Errorcatch
        if (playerController == null) {
            Debug.LogWarning("UIManager: PlayerController not found");
        }
        scoreText.text = "Score: ";
    }

    void Update() {
        // Update the health display based on the player's current health points
        if (playerController != null) {
            healthText.text = "Health: " + playerController.GetCurrentHealth().ToString();
            
        }
    }

    // Update score text method
    public void UpdateScoreText(int score) {
        scoreText.text = "Score: " + score.ToString();
    }
}