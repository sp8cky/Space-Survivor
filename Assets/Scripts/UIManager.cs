using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour {
    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    
    void Start() {
        scoreText.text = "Score: 0";
        healthText.text = "Health: " + 3.ToString();
        UpdateHighScoreText(GameManager.instance.GetPlayerHighScore());
    }

    // Update score and highscore text methods
    public void UpdateScoreText(int score) { scoreText.text = "Score: " + score.ToString(); }
    public void UpdateHighScoreText(int highScore) { highScoreText.text = "High Score: " + highScore.ToString(); }
    public void UpdatePlayerHealthText(int health) { healthText.text = "Health: " + health.ToString(); }
}