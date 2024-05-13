using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {
    private PlayerController playerController;
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        // collision detection when bullet hits a wall -> bullet gets destroyed
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

        // Collision detection when bullet hits a health item
        if (other.gameObject.CompareTag("HealthItem")) {
            Debug.Log("Collision Bullet with Health Item");
            if (playerController != null) playerController.GainHealth(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // Collision detection when bullet hits a shoot item
        if (other.gameObject.CompareTag("ShootItem")) {
            Debug.Log("Collision Bullet with Shoot Item");
            if (playerController != null) playerController.IncreaseAttackSpeed(2);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
