using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private PlayerController playerController;

    void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Enemy with Wall");
            playerController.LoseHealth(1); 
            Destroy(gameObject);
        }
    }
}
