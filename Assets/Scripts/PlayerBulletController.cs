using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {
    private PlayerController playerController;

    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null) Debug.LogError("PlayerController not found!");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // collision detection when bullet hits a wall
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Bullet with Wall");
            Destroy(gameObject);
        }
        
        // collision detection when bullet hits an enemy -> score increases
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision Bullet with Enemy");
            GameManager.instance.IncreaseScore(1);
            Destroy(gameObject);
        }

        // Collision detection with health item
        if (other.gameObject.name.Contains("HealthItem")) {
            Debug.Log("Collision Bullet with Health Item");
            playerController.GainHealth(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Collision detection with shoot item
        if (other.gameObject.name.Contains("ShootItem")) {
            Debug.Log("Collision Bullet with Shoot Item");
            playerController.IncreaseAttackSpeed(3);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Collision detection with speed item
        if (other.gameObject.name.Contains("SpeedItem")) {
            Debug.Log("Collision Bullet with Speed Item");
            playerController.IncreasePlayerSpeed(8);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
