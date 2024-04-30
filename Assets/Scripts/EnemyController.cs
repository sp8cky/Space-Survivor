using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    protected PlayerController playerController;
    protected int maxHealth;
    protected int currentHealth; 
    protected Rigidbody2D rb;
    public float fallSpeed = 2f;

    protected virtual void Start() {
        playerController = FindObjectOfType<PlayerController>();
        maxHealth = 1;
        currentHealth = maxHealth;

        // Rigidbody-Komponente erstellen und einstellen
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // Das Objekt soll kinematisch sein, um von Kollisionen unbeeinflusst zu bleiben
    }

    protected virtual void Update() {
        rb.velocity = new Vector2(0, -fallSpeed);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Collision Enemy with Wall");
            playerController.LoseHealth(1); 
            Destroy(gameObject);
        }
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Debug.Log("Collision Enemy with Bullet");
            TakeDamage(1);
        }
    }

    protected virtual void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount; 
        if (currentHealth <= 0) Destroy(gameObject);  
    }
}