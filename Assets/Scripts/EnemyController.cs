using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// parent class for all enemies, this is basic enemy
public class EnemyController : MonoBehaviour {
    protected PlayerController playerController;
    protected int maxHealth;
    protected int currentHealth; 
    protected Rigidbody2D rb;
    private float fallSpeed = 2f;

    protected virtual void Start() {
        playerController = FindObjectOfType<PlayerController>();
        maxHealth = 1;
        currentHealth = maxHealth;

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // dont get affected by physics
    }

    protected virtual void Update() { rb.velocity = new Vector2(0, -fallSpeed); }

    // enemy hits wall -> player loses health
    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Enemy with Wall");
            playerController.LoseHealth(1); 
            Destroy(gameObject);
        }
    }
    
    // enemy hits bullet -> enemy takes damage
    protected virtual void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Debug.Log("Collision Enemy with Bullet");
            TakeDamage(1);
        }
    }

    // enemy takes damage
    protected virtual void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount; 
        if (currentHealth <= 0) Destroy(gameObject);  
    }
}