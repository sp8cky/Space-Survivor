using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager instance; 
    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text speedText;
    public TMP_Text shootText;

    void Awake() {
        // Create singleton-instanz
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    void Start() {
        scoreText.text = "Score: 0";
        healthText.text = "Health: " + GameManager.instance.GetPlayerMaxHealth().ToString();
        UpdateHighScoreText(GameManager.instance.GetPlayerHighScore());
    }

    // Update score and highscore text methods
    public void UpdateScoreText(float score) { scoreText.text = "Score: " + score.ToString(); }
    public void UpdateHighScoreText(float highScore) { highScoreText.text = "High Score: " + highScore.ToString(); }
    public void UpdatePlayerHealthText(float health) { healthText.text = "Health: " + health.ToString(); }
    public void UpdateSpeedText(float time) { speedText.text = time >= 0 ? "Remaining: " + time.ToString("F0") : ""; }
    public void UpdateShootText(float time) { shootText.text = time >= 0 ? "Remaining: " + time.ToString("F0") : ""; }
}