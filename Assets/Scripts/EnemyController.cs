using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    // TODO: fix, that EnemyTwoLifeController has two lifes
    protected PlayerController playerController;
    protected int maxHealth;
    protected int currentHealth; 

    protected virtual void Start() {
        playerController = FindObjectOfType<PlayerController>();
        currentHealth = maxHealth;
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Enemy with Wall");
            playerController.LoseHealth(1); 
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Bullet")) {
            Debug.Log("Collision Enemy with Bullet");
            TakeDamage(1);
        }
    }

    protected virtual void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount; 
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}