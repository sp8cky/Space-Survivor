using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void StartGame() {
        Debug.Log("StartGame()");
        SceneManager.LoadScene("Level01");
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
