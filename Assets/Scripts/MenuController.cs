using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public static MenuController instance; // Singleton instance of the MenuController for easy access from anywhere in the game 

    void Awake() {
        // Create singleton instance
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    public void LoadMainMenuScene() {
        Debug.Log("LoadMainMenuScene()");
        SceneManager.LoadScene("MainMenu");
    }

    public void StartFirstLevel() {
        Debug.Log("StartFirstLevel()");
        SceneManager.LoadScene("Level01");
    }

    public void LoadGameOverScene() {
        Debug.Log("LoadGameOverScene()");
        SceneManager.LoadScene("GameOver");
    }

    public void Quit() {
        Debug.Log("Quit()");
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
